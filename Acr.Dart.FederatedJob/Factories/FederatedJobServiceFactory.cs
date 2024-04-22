using Acr.Dart.FederatedJob.Services;
using Microsoft.Data.SqlClient;

namespace Acr.Dart.FederatedJob.Factories
{
    public class FederatedJobServiceFactory : IFederatedJobServiceFactory
    {
        private readonly string _connectionString;
        public FederatedJobServiceFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IFederatedJobService CreateFederatedJobService()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                return new FederatedJobService(sqlConnection);
            }
        }
    }
}
