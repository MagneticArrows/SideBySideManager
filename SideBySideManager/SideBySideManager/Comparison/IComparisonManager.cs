using SideBySideManagerNuget.ComparisonAndAudit;

namespace SideBySideManagerNuget.Comparison;

public interface IComparisonManager
{
    public Task<BaseComparisonObject<T>> CompareAsync<T>(T item1, T item2);
}