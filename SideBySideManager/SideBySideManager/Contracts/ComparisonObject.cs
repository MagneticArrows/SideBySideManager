namespace SideBySideManagerNuget.Contracts;

// todo why is it inherting from BaseComparisonObject ?
// will any ComparisonObject will not have Comparison result?
public class ComparisonObject<T, E> : BaseComparisonObject<T>
{
    public E ComparisonResult { get; set; }
}
