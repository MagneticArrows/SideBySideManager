using SideBySideManagerNuget.Comparison;

namespace SideBySideManagerNuget.DataAuditor;

public class DefaultComparisonAuditManager : IComparisonAuditManager
{
    public async Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>
    {
        Console.WriteLine($"Responses equality status is: {comparisonObject.AreEqual}");//for example log warn when not equal
    }
}
