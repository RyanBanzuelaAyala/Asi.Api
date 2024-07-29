using Asi.Data.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AsiServiceData(this IServiceCollection services)
        {

            services.AddDbContext<AsiDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddScoped<DbContext, AsiDbContext>();

            return services;
        }
    }
}
