using Service;
using Model.DB;
using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.SideBySide;
using SideBySideManagerNuget.DataAuditor;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DiManager;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

        var sideBySideOptions = new SideBySideOptions()
        {
            CompareLogic = new CompareLogic()
        };
        // todo add the other services, add relevant configuration, make sure works
        services.AddSideBySideManager(sideBySideOptions);
        services.AddSingleton<IMongoClient>(provider => new MongoClient("mongodb://localhost:27010/"));
        services.AddSingleton<IAuditManager<IMongoClient>, AuditManager>();
    }
}

