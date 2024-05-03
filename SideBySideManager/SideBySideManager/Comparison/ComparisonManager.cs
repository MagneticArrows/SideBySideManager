using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;

namespace SideBySideManagerNuget;

public class ComparisonManager(ICompareLogic comparer, IComparisonAuditManager comparisonAuditManager) : IComparisonManager
{
    public async Task<bool> CompareAndAudit<T>(T? item1, T? item2)
    {       
        var result = comparer.Compare(item1, item2);

        var comparisonObject = new ComparisonObject<T, ComparisonResult>()
        {
            AreEqual = result.AreEqual,
            Item1 = item1,
            Item2 = item2,
            ComparisonResult = result
        };

        await comparisonAuditManager.AuditComparisonObject<ComparisonObject<T, ComparisonResult>, T>(comparisonObject);

        return result.AreEqual;
    }
}