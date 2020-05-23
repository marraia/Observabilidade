using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AcademiaDemoContext _context;

        public StockRepository(IConfiguration configuration)
        {
            _context = new AcademiaDemoContext(configuration);
        }

        public async Task InsertAsync(Stock stock)
        {
            await _context
                    .Stock
                    .InsertOneAsync(stock);
        }

        public async Task UpdateAsync(Stock stock)
        {
            var filter = Builders<Stock>.Filter.Eq(x => x.ItemId, stock.ItemId);

            var updateDefinition = Builders<Stock>.Update
                .Set(x => x.Ammount, stock.Ammount);

            await _context
                    .Stock
                    .UpdateOneAsync(filter, updateDefinition);
        }

        public async Task<Stock> GetByIdAsync(Guid id)
        {
            return await _context
                            .Stock
                            .AsQueryable()
                            .Where(item => item.ItemId == id)
                            .FirstOrDefaultAsync();
        }

    }
}
