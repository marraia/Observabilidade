using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Context;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AcademiaDemoContext _context;

        public SaleRepository(IConfiguration configuration)
        {
            _context = new AcademiaDemoContext(configuration);
        } 

        public async Task InsertAsync(Sale sale)
        { 
            await _context
                    .Sale
                    .InsertOneAsync(sale);
        }
    }
}
