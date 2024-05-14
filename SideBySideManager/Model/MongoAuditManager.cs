using Contracts.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public class MongoAuditManager : IAuditManager
{
    private readonly IMongoCollection<BaseComparisonAuditItemDto> _collection;

    public MongoAuditManager(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("myDbName");
        _collection = database.GetCollection<BaseComparisonAuditItemDto>("myCollectionName");
    }   

    public async Task SaveComparisonAuditItem<TResponseObject>(ComparisonAuditItemDto<TResponseObject> comparisonAuditItemDto) where TResponseObject : class
    {
        await _collection.InsertOneAsync(comparisonAuditItemDto);
    }
}
