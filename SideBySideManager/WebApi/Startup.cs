using Service;
using Model.DB;
using SideBySideManagerNuget;
using KellermanSoftware.CompareNetObjects;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton(configuration);
        SetDiRegistration(services);
    }

    private static void SetDiRegistration(IServiceCollection services)
    {
        services.AddSingleton<IExampleService, ExampleService>();
        services.AddSingleton<IDbManager, DbManager>();

        //todo implement di manager - include options for data auditor, logging and comparisonManager, end product one command with potential providers
        services.AddSingleton<IComparisonManager, ComparisonManager>();
        services.AddSingleton<ISideBySideManager, SideBySideManager>();
        services.AddSingleton<ICompareLogic>(provider =>
        {
            var comparer = new CompareLogic();
            comparer.Config.MaxDifferences = 5;//todo - we will support only several configurations
            return comparer;
        });//todo uninstall the CompareNETObjects nuget from web api
    }
}

