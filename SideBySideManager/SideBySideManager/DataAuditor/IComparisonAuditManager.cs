namespace SideBySideManagerNuget.DataAuditor;

public interface IComparisonAuditManager
{
    public Task AuditComparisonObject<T>(T comparisonObject);
}
