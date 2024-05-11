using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.DataAuditor;

public interface IAuditManager<T> where T : class
{
    public Task AuditComparisonObject<T, E>(T comparisonObject) where T : BaseComparisonObject<E>;
}
