using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acr.Dart.FederatedJob.Services
{
    public interface IFederatedJobService
    {
        void UpdateFederatedJobStatus(Guid transactionId, int status);
        bool CheckIfTransactionExists(Guid transactionId);
    }
}
