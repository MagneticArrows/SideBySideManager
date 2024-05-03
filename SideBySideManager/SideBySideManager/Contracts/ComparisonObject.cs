namespace SideBySideManagerNuget.Contracts;

public class ComparisonObject<T, E> : BaseComparisonObject<T>
{
    public E ComparisonResult { get; set; }
}
