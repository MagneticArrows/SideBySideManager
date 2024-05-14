using KellermanSoftware.CompareNetObjects;

namespace SideBySideManagerNuget.Comparison;

public class ComparisonManager(ICompareLogic comparer) : IComparisonManager
{
    public async Task<ComparisonResult> CompareAsync<T>(T? item1, T? item2) where T : class
    {
        var result = comparer.Compare(item1, item2);
        return result;
    }
}