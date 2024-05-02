using Contracts.Http;

namespace Service;

public interface IExampleService
{
    public Task<SomeServiceResponse> RunExample();
}
