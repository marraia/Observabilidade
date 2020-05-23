using AcademiaDemo.Application.AppSale.Input;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.Interfaces
{
    public interface ISaleAppService
    {
        Task InsertAsync(SaleInput sale);
    }
}
