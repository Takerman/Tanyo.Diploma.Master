using Microsoft.AspNetCore.Mvc;
using FMI.Gateways.Data.Entities;
using FMI.Gateways.Services.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FMI.Gateways.API.Controllers
{
    [Produces("application/json")]
    [SwaggerTag("Peripheral Devices")]
    public class PeripheralDeviceController : Controller
    {
        private readonly IPeripherialDeviceService _peripherialDeviceService;

        public PeripheralDeviceController(IPeripherialDeviceService peripherialDeviceService)
        {
            _peripherialDeviceService = peripherialDeviceService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(PeripheralDevice device)
        {
            var response = await _peripherialDeviceService.Add(device);

            if (!string.IsNullOrEmpty(response))
            {
                return BadRequest(response);
            }

            return Ok(device);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _peripherialDeviceService.Remove(id);

            if (!string.IsNullOrEmpty(response))
            {
                return BadRequest(response);
            }

            return Ok();
        }
    }
}