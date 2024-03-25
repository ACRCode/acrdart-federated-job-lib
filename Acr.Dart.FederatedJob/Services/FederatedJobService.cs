using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Acr.Dart.FederatedJob.Services
{
    public class FederatedJobService : IFederatedJobService
    {
        private readonly string _connectionString;
        public FederatedJobService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void UpdateFederatedJobStatus(Guid transactionId, int status)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFedJobForSiteByTransactionId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@transactionId", transactionId));
                sqlCommand.Parameters.Add(new SqlParameter("@status", status));
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex) {
                throw ex;
            }
            finally {
                sqlConnection?.Close();
            }         
        }

        public bool CheckIfTransactionExists(Guid transactionId)
        {

            bool success = false;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFedJobForSiteByTransactionId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@transactionId", transactionId));
                sqlCommand.ExecuteNonQuery(); 
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;               
            }
            finally
            {
                if (success && sqlConnection.State == ConnectionState.Open) {
                    sqlConnection?.Close();
                }                
            }
            return success;
        }
    }
}
