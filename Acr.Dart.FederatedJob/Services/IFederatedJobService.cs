using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acr.Dart.FederatedJob.Services
{
    public interface IFederatedJobService
    {
        bool UpdateFederatedJobStatus(Guid transactionId, int status);
        bool CheckTransactionExists(Guid transactionId);
        bool UpdateFederatedJobLogs(Guid transactionId, string logs);
    }
}
