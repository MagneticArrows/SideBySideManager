using Contracts.Http;

namespace Model;

public class OldServiceCaller
{
    public async Task<SomeServiceResponse> GetSomeServiceResponseAsync(SomeServiceRequest someServiceRequest)
    {
        await Task.Delay(3000);
        return new();
    }
}
