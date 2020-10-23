using System.Threading.Tasks;

/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    using Microsoft.Extensions.DependencyInjection;

    using System;

    /// <summary>
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        Task<int> StartAsync(IServiceProvider serviceProvider);
    }
}
