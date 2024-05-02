namespace SideBySideManagerNuget
{
    public interface IComparisonManager
    {
        public void Compare<T>(T? res1, T? res2);

        public void Compare<T>(T[] results);
    }
}