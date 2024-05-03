namespace SideBySideManagerNuget.ComparisonAndAudit;

public class ComparisonObject<T, E> : BaseComparisonObject<T>
{
    public E ComparisonResult { get; set; }
}
