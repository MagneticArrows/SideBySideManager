using MongoDB.Driver;
using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public class AuditManager : IAuditManager<IMongoClient>
{
    public IMongoClient MongoClient { get; set; }

    public AuditManager(IMongoClient mongoClient)
    {
        MongoClient = mongoClient;
    }

    public async Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>
    {
        MongoClient.GetDatabase("Test Collection");
    }
}
