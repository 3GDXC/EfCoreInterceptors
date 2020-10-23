using System;
using System.Threading.Tasks;
/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;


    /// <summary>
    /// </summary>
    public class Startup : IStartup
    {
        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        /// <summary>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleContext>(options =>
            {
                options.AddInterceptors(
                        new WasmConnectionInterceptor(),
                        new WasmCommandInterceptor(),
                        new WasmTransactionInterceptor()
                    );

                options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);

                options.UseSqlite("Data Source=.\\sample.db:wasm;");
            });
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<int> StartAsync(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<SampleContext>();
            dbContext.Database.EnsureCreated();


            return await Task.FromResult(1);
        }
    }

}
