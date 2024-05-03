using KellermanSoftware.CompareNetObjects;
using SideBySideManagerNuget.Contracts;

namespace SideBySideManagerNuget.Comparison;

public class DefaultComparisonManager(ICompareLogic comparer) : IComparisonManager
{
    public async Task<BaseComparisonObject<T>> CompareAsync<T>(T? item1, T? item2)
    {
        var result = comparer.Compare(item1, item2);
        var comparisonObject = new ComparisonObject<T, ComparisonResult>()
        {
            AreEqual = result.AreEqual,
            Item1 = item1,
            Item2 = item2,
            ComparisonResult = result
        };
        return comparisonObject;
    }
}