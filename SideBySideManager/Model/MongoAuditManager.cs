using MongoDB.Bson;
using MongoDB.Driver;
using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public class MongoAuditManager : IAuditManager
{
    private readonly IMongoCollection<ComparisonAuditItemDto2> _collection;

    public MongoAuditManager(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("myDbName");
        _collection = database.GetCollection<ComparisonAuditItemDto2>("myCollectionName");
    }   

    public async Task SaveComparisonAuditItem<TAuditObject>(ComparisonAuditItemDto comparisonAuditItemDto) where TAuditObject : class
    {
        var comparisonAuditItemDto2 = new ComparisonAuditItemDto2()
        {
            AreEquals = comparisonAuditItemDto.AreEquals,
            DifferencesString = comparisonAuditItemDto.DifferencesString,
            Response1 = comparisonAuditItemDto.Response1.ToBsonDocument(),
            Response2 = comparisonAuditItemDto.Response2.ToBsonDocument(),
        };

        await _collection.InsertOneAsync(comparisonAuditItemDto2);
    }
}

public class ComparisonAuditItemDto2
{
    public bool AreEquals { get; set; }
    public string DifferencesString { get; set; }

    public object Response1 { get; set; }

    public object Response2 { get; set; }
}

