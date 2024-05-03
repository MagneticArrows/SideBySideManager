using SideBySideManagerNuget.ComparisonAndAudit;

namespace SideBySideManagerNuget.SideBySide;

public class SideBySideManager(IComparisonAndAuditManager comparisonManager) : ISideBySideManager
{
    public async Task<T> RunSideBySideAsync<T>(Func<Task<T>> taskToInvoke1, Func<Task<T>> taskToInvoke2,
        bool runParallel = true, bool breakFlow = false)
    {
        if (breakFlow)
        {
            var (res1, res2) = await RunSideBySideAsync(taskToInvoke1, taskToInvoke2, runParallel);
            await comparisonManager.CompareAndAudit(res1, res2);
            return res1;
        }
        else
        {
            var taskToInvoke2WithNoException = GetWithoutExceptions(taskToInvoke2);
            var (res1, res2) = await RunSideBySideAsync(taskToInvoke1, taskToInvoke2WithNoException, runParallel);
            await comparisonManager.CompareAndAudit(res1, res2);
            return res1;
        }
    }

    private async Task<(T res1, T res2)> RunSideBySideAsync<T>(Func<Task<T>> task1, Func<Task<T>> task2, bool runParallel)
    {
        if (runParallel)
        {
            var results = await Task.WhenAll(task1(), task2());
            return (results[0], results[1]);
        }

        var res1 = await task1();
        var res2 = await task2();
        return (res1, res2);
    }

    private static Func<Task<T>> GetWithoutExceptions<T>(Func<Task<T>> taskToInvoke)
    {
        var taskToInvokeWithNoException = async () =>
        {
            try
            {
                return await taskToInvoke();
            }
            catch
            {
                return default;
            }
        };
        return taskToInvokeWithNoException;
    }
}