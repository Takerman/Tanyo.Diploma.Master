using FMI.Gateways.Services.Repositories.Contracts;

namespace FMI.Gateways.Services.Services.Contracts
{
    public interface IServiceBase
    {
        IRepositoryWrapper RepositoryWrapper { get; }
    }
}