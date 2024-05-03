using SideBySideManagerNuget.Comparison;
using SideBySideManagerNuget.DataAuditor;

namespace SideBySideManagerNuget.ComparisonAndAudit;

public class ComparisonAndAuditManager(IComparisonManager comparisonManager, IAuditManager auditManager) : IComparisonAndAuditManager
{
    public async Task CompareAndAudit<T>(T? item1, T? item2)
    {
        var comparisonObject = await comparisonManager.CompareAsync(item1, item2);
        await auditManager.AuditComparisonObject<BaseComparisonObject<T>, T>(comparisonObject);
    }
}