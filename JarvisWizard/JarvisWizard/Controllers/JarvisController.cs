using JarvisWizard.Services;
using Microsoft.AspNetCore.Mvc;

namespace JarvisWizard.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JarvisController : ControllerBase
    {
        private readonly GpioRaspberryService _gpioRaspberryService;

        public JarvisController()
        {
            _gpioRaspberryService = new GpioRaspberryService();
        }

        [HttpGet("rele")]
        public async Task<IActionResult> Rele([FromQuery] string action, int pulse = 1)
        {
            try
            {
                if (action.Equals("on"))
                {
                    _gpioRaspberryService.Rele(true);
                    return Ok("Relé ligado");
                }

   
                _gpioRaspberryService.Rele(false);
                return Ok("Relé desligado");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
