using AcademiaDemo.Application.AppPayment.Input;
using AcademiaDemo.Domain.Entities;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.Interfaces
{
    public interface IPaymentAppService
    {
        Task<Payment> InsertAsync(PaymentInput payment);
    }
}
