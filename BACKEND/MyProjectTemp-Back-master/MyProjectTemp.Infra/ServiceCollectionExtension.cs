using Microsoft.Extensions.DependencyInjection;
using MyProjectTemp.App.Interfaces;
using MyProjectTemp.Infra.Repository;

namespace MyProjectTemp.Infra
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IArchDesignRepository, ArchDesignRepository>();
        
        }
    }
}