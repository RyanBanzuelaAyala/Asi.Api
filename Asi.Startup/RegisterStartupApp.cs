using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Asi.Service.Startup.Startup
{
    public static class RegisterStartupApp
    {
        public static WebApplication AsiApp(this WebApplication app, IConfiguration configuration)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
