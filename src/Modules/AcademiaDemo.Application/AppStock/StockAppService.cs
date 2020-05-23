using AcademiaDemo.Application.Interfaces;
using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.AppStock
{
    public class StockAppService : IStockAppService
    {
        private readonly IStockRepository _stockRepository;

        public StockAppService(
            IStockRepository stockRepository
        )
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock> GetByIdAsync(Guid id)
        {
            return await _stockRepository
                            .GetByIdAsync(id)
                            .ConfigureAwait(false);
        }

        public async Task InsertAsync(Guid id, int ammount)
        {
            var stock = new Stock(id, ammount);

            await _stockRepository
                    .InsertAsync(stock)
                    .ConfigureAwait(false);
        }

        public async Task<Stock> UpdateAsync(Guid id)
        {
            var stock = await _stockRepository
                                .GetByIdAsync(id)
                                .ConfigureAwait(false);

            stock.Withdraw();

            await _stockRepository
                    .UpdateAsync(stock)
                    .ConfigureAwait(false);

            return stock;
        }
    }
}
