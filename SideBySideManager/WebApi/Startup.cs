using Service;
using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.DiManager;
using MongoDB.Driver;
using SideBySideManagerNuget.DataAuditor;

namespace WebApi;

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
        services.AddSingleton<IMongoClient>(provider => new MongoClient("mongodb://localhost:27017/"));

        services.AddSideBySideManager<MongoAuditManager>(new SideBySideOptions()
        {
            CompareLogic = new CompareLogic()
        });
    }
}

