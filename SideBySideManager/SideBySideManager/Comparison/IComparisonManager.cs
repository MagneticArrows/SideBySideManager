using KellermanSoftware.CompareNetObjects;

namespace SideBySideManagerNuget.Comparison;

public interface IComparisonManager
{
    public Task<ComparisonResult> CompareAsync<T>(T? item1, T? item2) where T : class;
}