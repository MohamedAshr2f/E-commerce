using Ecommerce.Service.Abstracts;
using Ecommerce.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
