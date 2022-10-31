using FMI.Gateways.Data.Contexts;
using FMI.Gateways.Data.Entities;
using FMI.Gateways.Services.Repositories.Contracts;

namespace FMI.Gateways.Services.Repositories
{
    public class GatewayRepository : RepositoryBase<Gateway>, IGatewayRepository
    {
        public GatewayRepository(GatewaysContext context)
            : base(context)
        {
        }
    }
}