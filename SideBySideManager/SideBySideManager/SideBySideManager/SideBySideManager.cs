namespace SideBySideManagerNuget;

public class SideBySideManager(IComparisonManager comparisonManager) : ISideBySideManager
{//todo cleanup
    public async Task<T> RunSideBySideAsync<T>(Func<Task<T>> task1, Func<Task<T>> task2, bool runParallel = true, bool breakFlow = false)
    {
        if (breakFlow)
        {
            if (runParallel)
            {
                var results = await Task.WhenAll(task1(), task2());
                comparisonManager.CompareAndAudit(results[0], results[1]);
                return results.First();
            }

            var res1 = await task1();
            var res2 = await task2();
            comparisonManager.CompareAndAudit(res1, res2);
            return res1;
        }
        else
        {
            var task2WithNoExceptions = async () =>
            {
                try
                {
                    return await task2();
                }
                catch
                {
                    return default;
                }
            };

            if (runParallel)
            {
                var results = await Task.WhenAll(task1(), task2WithNoExceptions());
                if(results.Last() is not null)
                    comparisonManager.CompareAndAudit(results[0], results[1]);

                return results.First();
            }

            var res1 = await task1();
            var res2 = await task2WithNoExceptions();

            if (res2 is not null)
                comparisonManager.CompareAndAudit(res1, res2);
            return res1;
        }
    }
}