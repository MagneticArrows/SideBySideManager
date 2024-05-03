using Newtonsoft.Json;//todo remove this nuget

namespace SideBySideManagerNuget.DataAuditor;

public class ComparisonAuditManager : IComparisonAuditManager
{
    public async Task AuditComparisonObject<T>(T comparisonObject)
    {
        var jsonRepresentation = JsonConvert.SerializeObject(comparisonObject);
        Console.WriteLine(jsonRepresentation);
    }
}
