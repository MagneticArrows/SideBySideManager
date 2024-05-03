namespace SideBySideManagerNuget;

public interface IComparisonManager//todo implement
{
    public bool CompareAndAudit<T>(T? obj1, T? obj2);
}