using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MoviesManager.Models;

namespace MoviesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a host variable to manage the hosting process
            var host = CreateHostBuilder(args).Build();
           
            // Using the host processs we create an scope for the execution
            using (var scope = host.Services.CreateScope()) {
                
                // Get the service provider
                var services = scope.ServiceProvider;

                // Initialize the program validating if seeding is needed
                try { 
                    SeedData.Initialize(services); 
                }
                catch (Exception ex) {
                    // If it is not, we create an instance of the logger and send the error. 
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }

                // After all the initialization we run the host manager
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
