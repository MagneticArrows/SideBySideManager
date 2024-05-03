using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public interface IAuditManager
{
    public Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>;
}
