using System;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Hosting.Internal;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// </summary>
    class Program
    {
        static IHostEnvironment hostEnvironment;
        static IServiceProvider serviceProvider;
        static IConfiguration configuration;

        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<int> Main(string[] args)
        {

            hostEnvironment = new HostingEnvironment();
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", false, true)
                .AddJsonFile($"appsettings.{hostEnvironment?.EnvironmentName ?? "Production" }.json", true, true)
                .AddEnvironmentVariables("WASM_")
                .AddCommandLine(args ?? new string[] { })
                .Build();
            var serviceCollection = new ServiceCollection()
                .AddLogging(setup =>
                {
                    setup
                        .AddConfiguration(configuration)
                        .AddConsole()
                        .AddDebug();
                });

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IStartup, Startup>();

            serviceProvider = serviceCollection
                .BuildServiceProvider();

            var startup = serviceProvider.GetRequiredService<IStartup>();
            startup.ConfigureServices(serviceCollection);
            return await startup.StartAsync(serviceCollection.BuildServiceProvider());
        }
    }
}
