using AcademiaDemo.Infrastructure.IoC.Application;
using AcademiaDemo.Infrastructure.IoC.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaDemo.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new RepositoryBootstrapper().ChildServiceRegister(services);
        }
    }
}
