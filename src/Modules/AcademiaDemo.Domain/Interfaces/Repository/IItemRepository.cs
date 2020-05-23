using AcademiaDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaDemo.Domain.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task InsertAsync(Item item);
        Task<Item> GetByIdAsync(Guid id);
        Task<IEnumerable<Item>> GetAllAsync();
    }
}
