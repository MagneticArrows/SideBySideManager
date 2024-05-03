namespace SideBySideManagerNuget.Comparison;

public class ComparisonObject<T, E>
{
    public T Item1 {  get; set; } 
    public T Item2 {  get; set; } 
    public E ComparisonResult {  get; set; } 
}
