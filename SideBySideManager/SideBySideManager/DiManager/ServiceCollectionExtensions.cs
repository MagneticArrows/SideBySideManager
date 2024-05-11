using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.DependencyInjection;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;
using SideBySideManagerNuget.SideBySide;

namespace SideBySideManagerNuget.DiManager
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSideBySideManager(this IServiceCollection services)
        {
            SetDefaultDi(services);
            
            services.AddSingleton<ICompareLogic, CompareLogic>();

            return services;
        }

        public static IServiceCollection AddSideBySideManager(this IServiceCollection services, SideBySideOptions configureOptions)
        {
            SetDefaultDi(services);
            
            services.AddSingleton<ICompareLogic>(provider =>
            {
                return configureOptions.CompareLogic;
            });

            return services;
        }

        private static void SetDefaultDi(IServiceCollection services)
        {
            services.AddTransient<ISideBySideManager, SideBySideManager>();
            services.AddSingleton<IComparisonManager, DefaultComparisonManager>();
            services.AddSingleton<IAuditManager, DefaultAuditManager>();
        }
    }
}
