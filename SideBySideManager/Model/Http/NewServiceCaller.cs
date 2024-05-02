using Contracts.Http;

namespace Model.Http;

public class NewServiceCaller
{
    public async Task<SomeServiceResponse> GetSomeServiceResponseAsync(SomeServiceRequest someServiceRequest)
    {
        throw new InvalidOperationException();
    }
}
