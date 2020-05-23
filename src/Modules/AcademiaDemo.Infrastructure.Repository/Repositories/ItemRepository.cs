using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AcademiaDemoContext _context;

        public ItemRepository(IConfiguration configuration)
        {
            _context = new AcademiaDemoContext(configuration);
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            return await _context
                            .Item
                            .AsQueryable()
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Item item)
        {
            await _context
                    .Item
                    .InsertOneAsync(item);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context
                            .Item
                            .AsQueryable()
                            .ToListAsync();
        }
    }
}
