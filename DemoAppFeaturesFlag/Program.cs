using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace DemoAppFeaturesFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((hosting, config) =>
                    {
                        var settings = config.Build();
                        var connection = settings.GetConnectionString("AppConfig");

                        config.AddAzureAppConfiguration(options =>
                            options.Connect(connection)
                                .UseFeatureFlags(featureFlagOptions =>
                                    featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(5)));
                    }).UseStartup<Startup>());
    }
}
