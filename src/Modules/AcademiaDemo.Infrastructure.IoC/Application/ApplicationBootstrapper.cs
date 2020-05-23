using AcademiaDemo.Application.AppItem;
using AcademiaDemo.Application.AppPayment;
using AcademiaDemo.Application.AppSale;
using AcademiaDemo.Application.AppStock;
using AcademiaDemo.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDemo.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ISaleAppService, SaleAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IStockAppService, StockAppService>();
        }
    }
}
