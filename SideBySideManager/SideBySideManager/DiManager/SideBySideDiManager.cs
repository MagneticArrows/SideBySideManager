using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.DependencyInjection;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;
using SideBySideManagerNuget.SideBySide;

namespace SideBySideManagerNuget.DiManager;

public static class SideBySideDiManager//todo make sure the di is efficient
{
    public static IServiceCollection AddSideBySideManager<TAuditManager>(this IServiceCollection services, SideBySideOptions configureOptions = null)
        where TAuditManager : class, IAuditManager
    {
        SetMandatoryDi(services);
        services.AddSingleton<IAuditManager, TAuditManager>();

        if (configureOptions is null)
        {
            services.AddSingleton<ICompareLogic, CompareLogic>();
            return services;
        }
       
        services.AddSingleton<ICompareLogic>(provider =>
        {
            return configureOptions.CompareLogic;
        });

        return services;
    }

    private static void SetMandatoryDi(IServiceCollection services)
    {
        services.AddTransient<ISideBySideManager, SideBySideManager>();
        services.AddSingleton<IComparisonManager, ComparisonManager>();
    }
}
