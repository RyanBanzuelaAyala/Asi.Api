using Asi.Application.Repository.V1;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AsiServiceApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
