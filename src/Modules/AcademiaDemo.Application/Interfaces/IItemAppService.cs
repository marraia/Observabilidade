using AcademiaDemo.Application.AppItem.Input;
using AcademiaDemo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.Interfaces
{
    public interface IItemAppService
    {
        Task InsertAsync(ItemInput item);
        Task<IEnumerable<Item>> GetAllAsync();
    }
}
