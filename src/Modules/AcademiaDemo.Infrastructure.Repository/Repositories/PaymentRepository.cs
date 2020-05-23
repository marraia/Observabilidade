using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Context;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AcademiaDemoContext _context;

        public PaymentRepository(IConfiguration configuration)
        {
            _context = new AcademiaDemoContext(configuration);
        }

        public async Task InsertAsync(Payment payment)
        {
            await _context
                    .Payment
                    .InsertOneAsync(payment);
        }
    }
}
