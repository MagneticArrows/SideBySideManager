using SideBySideManagerNuget.Comparison;

namespace SideBySideManagerNuget.DataAuditor;

public interface IComparisonAuditManager
{
    public Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>;
}
