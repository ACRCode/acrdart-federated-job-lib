using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Acr.Dart.FederatedJob.Services
{
    public class FederatedJobService : IFederatedJobService
    {
        private readonly string _connectionString;
        public FederatedJobService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool UpdateFederatedJobStatus(Guid transactionId, int status)
        {            
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UpdateFedJobStatus", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@TransactionId", transactionId));
                sqlCommand.Parameters.Add(new SqlParameter("@Status", status));
                var result = sqlCommand.ExecuteNonQuery();
                return result > 0 ? true : false;
            }
            catch(Exception ex) {                
               
                return false;
                throw ex;
            }
            finally {
                sqlConnection?.Close();
            }         
        }

        public bool CheckTransactionExists(Guid transactionId)
        {           
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetFedJobForSite", sqlConnection)
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
                //var result = sqlCommand.ExecuteNonQuery();
                //return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;               
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) {
                    sqlConnection?.Close();
                }                
            }          
        }

        public bool UpdateFederatedJobLogs(Guid transactionId, string logs)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UpdateFedJobLogs", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add(new SqlParameter("@TransactionId", transactionId));
                sqlCommand.Parameters.Add(new SqlParameter("@Logs", logs));
                var result = sqlCommand.ExecuteNonQuery();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection?.Close();
            }
        }
    }
}
