using Microsoft.AspNetCore.Mvc;
using FMI.Gateways.Services.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FMI.Gateways.API.Controllers
{
    [SwaggerTag("Gateways")]
    [Produces("application/json")]
    public class GatewaysController : Controller
    {
        private IGatewayService _gatewayService;

        public GatewaysController(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet("Get", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var gateways = await _gatewayService.GetAll();

            return Ok(gateways);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gateway = await _gatewayService.Get(id);

            if (gateway == null)
            {
                return NotFound("The Gateway record couldn't be found.");
            }

            return Ok(gateway);
        }
    }
}