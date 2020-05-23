using AcademiaDemo.Application.AppPayment.Input;
using AcademiaDemo.Application.AppPayment.Output;
using AcademiaDemo.Application.AppSale.Input;
using AcademiaDemo.Application.AppStock.Input;
using AcademiaDemo.Application.AppStock.Output;
using AcademiaDemo.Application.Interfaces;
using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Gateway.Interfaces;
using Elastic.Apm;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.AppSale
{
    public class SaleAppService : ISaleAppService
    {
        private string urlPayment = "";
        private string urlStock = "";
        private readonly IHttpClientGateway<PaymentInput, PaymentOutput> _paymentGateway;
        private readonly IHttpClientGateway<StockInput, StockOutput> _stockGateway;
        private readonly IItemRepository _itemRepository;
        private readonly ISaleRepository _saleRepository;

        public SaleAppService(
            IConfiguration configuration,
            IHttpClientGateway<PaymentInput, PaymentOutput> paymentGateway,
            IHttpClientGateway<StockInput, StockOutput> stockOutput,
            IItemRepository itemRepository,
            ISaleRepository saleRepository
        )
        {
            urlPayment = configuration.GetSection("Payment").Value;
            urlStock = configuration.GetSection("Stock").Value;
            _paymentGateway = paymentGateway;
            _stockGateway = stockOutput;
            _itemRepository = itemRepository;
            _saleRepository = saleRepository;
        }
        public async Task InsertAsync(SaleInput input)
        {
            var itens = new List<Item>();
            var total = 0.00M;

            if (input.Itens.Count <= 0) 
                throw new Exception("Para a venda, é necessário pelo menos informar um item");
                

            foreach (var itemId in input.Itens)
            {
                var item = await _itemRepository
                                    .GetByIdAsync(itemId)
                                    .ConfigureAwait(false);

                var stock = await _stockGateway
                                    .PutAsync(urlStock, itemId)
                                    .ConfigureAwait(false);

                if (!stock.Success)
                    throw new Exception(stock.ErrorMessage);

                itens.Add(item);
                total += item.Price;
            }

            var payment = new PaymentInput()
            {
                CardNumber = input.Payment.CardNumber,
                SubDivision = input.Payment.SubDivision,
                Total = total
            };

            var response = await _paymentGateway
                                    .PostAsync(urlPayment, payment)
                                    .ConfigureAwait(false);

            if (!response.Success)
                throw new Exception(response.ErrorMessage);


            var sale = new Sale(new Payment(response.ReadToObject.Id,
                                                response.ReadToObject.CardNumber,
                                                response.ReadToObject.SubDivision,
                                                response.ReadToObject.Total,
                                                response.ReadToObject.TotalSubDivision));
            sale.AddItems(itens);

            await _saleRepository
                    .InsertAsync(sale)
                    .ConfigureAwait(false);
        }
    }
}
