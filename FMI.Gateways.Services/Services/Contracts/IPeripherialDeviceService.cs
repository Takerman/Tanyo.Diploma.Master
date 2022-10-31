using FMI.Gateways.Data.Entities;
using System.Threading.Tasks;

namespace FMI.Gateways.Services.Services.Contracts
{
    public interface IPeripherialDeviceService : IServiceBase
    {
        Task<string> Add(PeripheralDevice device);
        Task<string> Remove(int id);
    }
}