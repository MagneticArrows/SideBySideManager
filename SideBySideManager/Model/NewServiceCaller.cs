using Contracts.Http;

namespace Model;

public class NewServiceCaller
{
    public async Task<SomeServiceResponse> GetSomeServiceResponseAsync(SomeServiceRequest someServiceRequest)
    {
        throw new InvalidOperationException();
    }
}
