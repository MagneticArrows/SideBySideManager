using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;

namespace SideBySideManagerNuget;

public class ComparisonManager(ICompareLogic comparer,
    IComparisonAuditManager comparisonAuditManager) : IComparisonManager
{
    public bool CompareAndAudit<T>(T? obj1, T? obj2)
    {       
        var result = comparer.Compare(obj1, obj2);

        var comparisonObject = new ComparisonObject<T, ComparisonResult>()
        {
            Obj1 = obj1,
            Obj2 = obj2,
            ComparisonResult = result
        };

        comparisonAuditManager.AuditComparisonObject(comparisonObject);
    }
}