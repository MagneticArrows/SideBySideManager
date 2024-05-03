namespace SideBySideManagerNuget.Comparison;

public class ComparisonObject<T, E>
{
    public T Obj1 {  get; set; } 
    public T Obj2 {  get; set; } 
    public E ComparisonResult {  get; set; } 
}
