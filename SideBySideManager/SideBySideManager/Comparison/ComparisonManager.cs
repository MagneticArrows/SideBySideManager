using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;

namespace SideBySideManagerNuget;

public class ComparisonManager(ICompareLogic comparer,
    IComparisonAuditManager comparisonAuditManager) : IComparisonManager
{
    public bool CompareAndAudit<T>(T? item1, T? item2)
    {       
        var result = comparer.Compare(item1, item2);

        var comparisonObject = new ComparisonObject<T, ComparisonResult>()
        {
            Item1 = item1,
            Item2 = item2,
            ComparisonResult = result
        };

        comparisonAuditManager.AuditComparisonObject(comparisonObject);

        return result.AreEqual;
    }
}