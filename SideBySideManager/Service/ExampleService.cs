using Contracts.Http;
using Model.Http;
using SideBySideManagerNuget;

namespace Service;
public class ExampleService(ISideBySideManager sideBySideManager) : IExampleService
{
    public async Task<SomeServiceResponse> RunExample()
    {  
        var oldCaller = new OldServiceCaller();
        var newCaller = new NewServiceCaller();

        var result = await sideBySideManager.RunSideBySideAsync(
            () => oldCaller.GetSomeServiceResponseAsync(new()),
            () => newCaller.GetSomeServiceResponseAsync(new()));

        return result;
    }
}