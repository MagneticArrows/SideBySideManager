namespace SideBySideManagerNuget;

public class SideBySideManager(IComparisonManager comparisonManager) : ISideBySideManager
{
    public async Task<T> RunSideBySideAsync<T>(Func<Task<T>> task1, Func<Task<T>> task2,
        bool runParallel = true, bool breakFlow = false)
    {
        if (breakFlow)     
            return await RunSideBySideAsync(task1, task2, runParallel);

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

        return await RunSideBySideAsync(task1, task2WithNoExceptions, runParallel);            
    }

    private async Task<T> RunSideBySideAsync<T>(Func<Task<T>> task1, Func<Task<T>> task2, bool runParallel)
    {
        if (runParallel)
        {
            var results = await Task.WhenAll(task1(), task2());
            await comparisonManager.CompareAndAudit(results[0], results[1]);
            return results.First();
        }

        var res1 = await task1();
        var res2 = await task2();
        await comparisonManager.CompareAndAudit(res1, res2);
        return res1;
    }
}