using FMI.Gateways.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMI.Gateways.Services.Services.Contracts
{
    public interface IGatewayService : IServiceBase
    {
        Task<Gateway> Get(int id);
        Task<IEnumerable<Gateway>> GetAll();
    }
}