using AcademiaDemo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.Interfaces
{
    public interface IStockAppService
    {
        Task InsertAsync(Guid id, int ammount);
        Task<Stock> UpdateAsync(Guid id);
        Task<Stock> GetByIdAsync(Guid id);
    }
}
