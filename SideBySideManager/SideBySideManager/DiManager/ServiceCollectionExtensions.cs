using Microsoft.Extensions.DependencyInjection;
using SideBySideManagerNuget.SideBySide;

namespace SideBySideManagerNuget.DiManager
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSideBySideManager(this IServiceCollection services, Action<SideBySideOptions> configureOptions)
        {
            // Bind the configuration options
            var options = new SideBySideOptions();
            configureOptions(options);
            services.AddSingleton(options);

            // Register the actual service implementation with DI
            services.AddTransient<ISideBySideManager, SideBySideManager>();

            return services;
        }

    }
}
