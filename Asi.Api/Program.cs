
using Asi.Service.Startup.Startup;

var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

var builder = WebApplication.CreateBuilder(args)
    .AsiStartup(configuration);

builder.Build().AsiApp(configuration).Run();
