using Acr.Dart.FederatedJob.Services;

namespace Acr.Dart.FederatedJob.Factories
{
    public interface IFederatedJobServiceFactory
    {
       IFederatedJobService CreateFederatedJobService();
    }
}