namespace SideBySideManagerNuget.ComparisonAndAudit;

public interface IComparisonAndAuditManager
{
    public Task CompareAndAudit<T>(T? item1, T? item2);
}