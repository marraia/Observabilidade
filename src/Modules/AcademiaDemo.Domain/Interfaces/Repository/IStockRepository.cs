using AcademiaDemo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Domain.Interfaces.Repository
{
    public interface IStockRepository
    {
        Task InsertAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task<Stock> GetByIdAsync(Guid id);
    }
}
