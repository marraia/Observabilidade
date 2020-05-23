using AcademiaDemo.Domain.Entities;
using System.Threading.Tasks;

namespace AcademiaDemo.Domain.Interfaces.Repository
{
    public interface IPaymentRepository
    {
        Task InsertAsync(Payment payment);
    }
}
