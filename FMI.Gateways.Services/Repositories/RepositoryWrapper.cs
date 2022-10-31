using FMI.Gateways.Data.Contexts;
using FMI.Gateways.Services.Repositories.Contracts;

namespace FMI.Gateways.Services.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private GatewaysContext _context;
        private IGatewayRepository _gateway;
        private IPeripherialDeviceRepository _perepherialDevice;

        public IGatewayRepository Gateway
        {
            get
            {
                if (_gateway == null)
                {
                    _gateway = new GatewayRepository(_context);
                }

                return _gateway;
            }
        }

        public IPeripherialDeviceRepository PeripherialDevice
        {
            get
            {
                if (_perepherialDevice == null)
                {
                    _perepherialDevice = new PeripheralDeviceRepository(_context);
                }

                return _perepherialDevice;
            }
        }

        public RepositoryWrapper(GatewaysContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}