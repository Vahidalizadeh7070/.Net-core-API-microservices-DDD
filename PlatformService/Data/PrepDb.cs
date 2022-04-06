using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app,bool isProd)
        {
            using(var serviceScope=app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(),isProd);
            }
            
        }
        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations ");
                try{
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations :{ex.Message}");
                }
            }


            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Data ...");
                context.Platforms.AddRange(
                    new Platforms(){Name=".Net",Cost="Free",Publisher="Microsoft"},
                    new Platforms(){Name="Django",Cost="Free",Publisher="Python"},
                    new Platforms(){Name="Docker",Cost="Free",Publisher="Docker"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have data");
            }
        }
    }
}