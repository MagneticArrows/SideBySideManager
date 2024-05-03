namespace SideBySideManagerNuget.Contracts
{
    public abstract class BaseComparisonObject<T>
    {
        public bool AreEqual { get; set; }
        public T Item1 { get; set; }
        public T Item2 { get; set; }
    }
}