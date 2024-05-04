namespace SideBySideManagerNuget.Contracts
{
    public abstract class BaseComparisonObject<T> // todo let's find a better name then Base
    {
        public bool AreEqual { get; set; }
        public T Item1 { get; set; }
        public T Item2 { get; set; }
    }
}