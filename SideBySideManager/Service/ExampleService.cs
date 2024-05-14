using Contracts.Http;
using Model;
using SideBySideManagerNuget.SideBySide;

namespace Service;
public class ExampleService(ISideBySideManager sideBySideManager) : IExampleService
{
    public async Task<SomeServiceResponse> RunExample()
    {  
        var oldCaller = new OldServiceCaller();
        var newCaller = new NewServiceCaller();

        var result = await sideBySideManager.RunSideBySideAsync(
            () => oldCaller.GetSomeServiceResponseAsync(new()),
            () => oldCaller.GetSomeServiceResponseAsync(new()));

        var result2 = await sideBySideManager.RunSideBySideAsync(
            () => oldCaller.GetSomeServiceResponseAsync(new()),
            () => newCaller.GetSomeServiceResponseAsync(new()));

        return result;
    }
}