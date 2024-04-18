﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Acr.Dart.FederatedJob.Services
{
    public interface IFederatedJobService
    {
        bool UpdateFederatedJobStatus(Guid transactionId, int status);
        bool CheckTransactionExists(Guid transactionId);
        bool UpdateFederatedJobLogs(Guid transactionId, string logs);
        DataSet GetFederatedJobByTransactionId(Guid transactionId);

        bool CheckSiteExistOrNotBySiteId(int siteId);
        DataSet FetchFedJobForSiteBySiteId(int siteId);
        bool CheckSiteExistOrNotByTransactionId(string transactionId);
        DataSet GetFedJobInputByTransactionId(string transactionId);
    }
}
