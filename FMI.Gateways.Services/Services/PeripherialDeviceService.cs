using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FMI.Gateways.Data.Entities;
using FMI.Gateways.Services.Repositories.Contracts;
using FMI.Gateways.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FMI.Gateways.Services.Services
{
    public class PeripherialDeviceService : IPeripherialDeviceService
    {
        private IConfiguration _configuration;
        private IRepositoryWrapper _repositoryWrapper;

        public PeripherialDeviceService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _repositoryWrapper = repositoryWrapper;
        }

        public IRepositoryWrapper RepositoryWrapper
        {
            get
            {
                return _repositoryWrapper;
            }
        }

        public async Task<string> Add(PeripheralDevice device)
        {
            try
            {
                var maxDevicesCount = Convert.ToInt32(_configuration["MaxDevices"]);

                var gatewayDevices = await _repositoryWrapper.PeripherialDevice.FindByCondition(x => x.GatewayId == device.GatewayId).ToListAsync();

                if (gatewayDevices.Count() >= maxDevicesCount)
                {
                    return "The gateway devices are up to the maximum of " + maxDevicesCount;
                }

                _repositoryWrapper.PeripherialDevice.Create(device);
                _repositoryWrapper.Save();

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message);
            }
        }

        public async Task<string> Remove(int id)
        {
            try
            {
                var device = await _repositoryWrapper.PeripherialDevice.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

                if (device == null)
                {
                    return "Device with such ID is not existing";
                }

                _repositoryWrapper.PeripherialDevice.Delete(device);

                _repositoryWrapper.Save();

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message);
            }
        }
    }
}