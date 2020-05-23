using AcademiaDemo.Application.AppItem.Input;
using AcademiaDemo.Application.Interfaces;
using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.AppItem
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IStockRepository _stockRepository;

        public ItemAppService(
            IItemRepository itemRepository,
            IStockRepository stockRepository
        )
        {
            _itemRepository = itemRepository;
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _itemRepository
                            .GetAllAsync()
                            .ConfigureAwait(false);
        }

        public async Task InsertAsync(ItemInput input)
        {
            if (string.IsNullOrEmpty(input.Description))
                throw new ArgumentNullException("Descrição do produto é obrigatório");

            if (input.Ammount <= 0)
                throw new ArgumentNullException("Quantidade de estoque necessita ser maior que zero");

            var item = new Item(input.Description, input.Price);

            await _itemRepository
                    .InsertAsync(item)
                    .ConfigureAwait(false);

            var stock = new Stock(item.Id, input.Ammount);

            await _stockRepository
                    .InsertAsync(stock)
                    .ConfigureAwait(false);
        }
    }
}
