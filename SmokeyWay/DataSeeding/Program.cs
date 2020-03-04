using System;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SmokeyWay;

namespace DataSeeding
{
    static class Program
    {
        static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SmokeyWayDbContext>();

                try
                {
                    SmokeyWayDbContextSeed.Initialize(services);
                }
                catch (Exception)
                {
                    throw new Exception("An error occurred seeding the DB.");
                }
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}