using Newtonsoft.Json;
using SideBySideManagerNuget.Comparison;

namespace SideBySideManagerNuget.DataAuditor;

public class ComparisonAuditManager : IComparisonAuditManager
{
    public async Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>
    {
        var Item1Json = JsonConvert.SerializeObject(comparisonObject.Item1);
        var Item2Json = JsonConvert.SerializeObject(comparisonObject.Item2);
        var ComparisonItemJson = JsonConvert.SerializeObject(comparisonObject);

        Console.WriteLine($"Responses equality status is: {comparisonObject.AreEqual}");//for example log warn when not equal
        Console.WriteLine(Item1Json);//for example audit in mongo
        Console.WriteLine(Item2Json);//for example audit in mongo
        Console.WriteLine(ComparisonItemJson);//for example audit in mongo
    }
}
