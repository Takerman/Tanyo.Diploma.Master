using Microsoft.EntityFrameworkCore;
using FMI.Gateways.Data.Entities;
using FMI.Gateways.Services.Repositories.Contracts;
using FMI.Gateways.Services.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMI.Gateways.Services.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GatewayService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IRepositoryWrapper RepositoryWrapper
        {
            get
            {
                return _repositoryWrapper;
            }
        }

        public async Task<Gateway> Get(int id)
        {
            return await _repositoryWrapper.Gateway.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Gateway>> GetAll()
        {
            return await _repositoryWrapper.Gateway.FindAll().ToListAsync();
        }
    }
}