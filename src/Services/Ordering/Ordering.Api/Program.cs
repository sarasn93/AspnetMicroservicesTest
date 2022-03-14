using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ordering.Api.Extentions;
using Ordering.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
           .Build()
           .MigrateDatabase<OrderContext>((context, services) =>
           {
               var logger = services.GetService<ILogger<OrderContextSeed>>();
               OrderContextSeed
                   .SeedAsync(context, logger)
                   .Wait();
           })
           .Run();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
