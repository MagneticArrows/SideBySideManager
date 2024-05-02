namespace SideBySideManagerNuget
{
    public interface IComparisonManager//todo implement
    {
        public void Compare<T>(T? res1, T? res2);

        public void Compare<T>(T[] results);
    }
}