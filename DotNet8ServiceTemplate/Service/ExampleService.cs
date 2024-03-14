using Model.DB;

namespace Service
{
    public class ExampleService : IExampleService
    {
        private readonly IDbManager _dapperClient;

        public ExampleService(IDbManager dapperClient)
        {
            _dapperClient = dapperClient;
        }

        public async Task<IEnumerable<int>> RunExample()
        {
            return new List<int>();
        }
    }
}