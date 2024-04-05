using System;
using System.Data;
using System.Data.SqlClient;

namespace Acr.Dart.FederatedJob.Services
{
    public class FederatedJobService : IFederatedJobService
    {
        private readonly SqlConnection _connectionString;       
        public FederatedJobService(SqlConnection connectionString)
        {
            _connectionString = connectionString;
        }
        public bool UpdateFederatedJobStatus(Guid transactionId, int status)
        {                        
            try
            {
                _connectionString.Open();
                SqlCommand sqlCommand = new SqlCommand("UpdateFedJobStatus", _connectionString)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@TransactionId", transactionId));
                sqlCommand.Parameters.Add(new SqlParameter("@Status", status));
                var result = sqlCommand.ExecuteNonQuery();
                return result > 0 ? true : false;
            }
            finally {
                _connectionString?.Close();
            }         
        }

        public bool CheckTransactionExists(Guid transactionId)
        {                      
            try
            {
                _connectionString.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFedJobForSite", _connectionString)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@TransactionId", transactionId));
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(sqlDataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                _connectionString?.Close();
            }          
        }

        public bool UpdateFederatedJobLogs(Guid transactionId, string logs)
        {            
            try
            {
                _connectionString.Open();
                SqlCommand sqlCommand = new SqlCommand("UpdateFedJobLogs", _connectionString)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@TransactionId", transactionId));
                sqlCommand.Parameters.Add(new SqlParameter("@Logs", logs));
                var result = sqlCommand.ExecuteNonQuery();
                return result > 0 ? true : false;
            }            
            finally
            {
                _connectionString?.Close();
            }
        }
    }
}
