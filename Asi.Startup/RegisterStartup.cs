using Asi.Application;
using Asi.Data;
using Asi.Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Asi.Service.Startup.Startup
{
    public static class RegisterStartup
    {
        public static WebApplicationBuilder AsiStartup(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AsiServiceData();
            builder.Services.AsiServiceApplication();
            builder.Services.AsiServiceInfraService();

            return builder;
        }
    }
}
