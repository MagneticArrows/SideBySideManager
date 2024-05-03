namespace SideBySideManagerNuget;

public interface IComparisonManager//todo implement
{
    public Task<bool> CompareAndAudit<T>(T? item1, T? item2);
}