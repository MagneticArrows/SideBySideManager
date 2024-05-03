using KellermanSoftware.CompareNetObjects;

namespace SideBySideManagerNuget
{
    public class ComparisonManager(ICompareLogic comparer) : IComparisonManager
    {
        public void Compare<T>(T? obj1, T? obj2)
        {       
            var result = comparer.Compare(obj1, obj2);

            if (result.AreEqual)
            {
                Console.WriteLine("Objects are equal");
            }
            else
            {
                Console.WriteLine("Objects are not equal");

                foreach (var difference in result.Differences)
                {
                    Console.WriteLine($"Difference found at {difference.PropertyName}: {difference.Object1Value} (Object1) vs {difference.Object2Value} (Object2)");
                }
            }
        }
    }
}