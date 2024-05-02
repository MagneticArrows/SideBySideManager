using Service;
using Model.DB;
using SideBySideManagerNuget;

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


        services.AddSingleton<IComparisonManager, ComparisonManager>();
        services.AddSingleton<ISideBySideManager, SideBySideManager>();
    }
}

