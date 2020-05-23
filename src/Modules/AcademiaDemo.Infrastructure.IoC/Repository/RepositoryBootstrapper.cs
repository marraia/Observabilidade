using AcademiaDemo.Domain.Interfaces.Repository;
using AcademiaDemo.Infrastructure.Repository.Gateway;
using AcademiaDemo.Infrastructure.Repository.Gateway.Interfaces;
using AcademiaDemo.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDemo.Infrastructure.IoC.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped(typeof(IHttpClientGateway<,>), typeof(HttpClientGateway<,>));
        }
    }
}
