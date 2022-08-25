using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Overlord.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatingSystemController : ControllerBase
    {
        private readonly ILogger<OperatingSystemController> _logger;
        private readonly IOperatingSystemController operatingSystemController;

        public OperatingSystemController(ILogger<OperatingSystemController> logger)
        {
            _logger = logger;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                operatingSystemController = new WindowsController();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new NotImplementedException();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new NotImplementedException();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("logoff")]
        public string Logoff(bool force)
        {
            operatingSystemController.Logoff(force);
            return "Done.";
        }

        [HttpGet("shutdown")]
        public string Shutdown(bool force)
        {
            operatingSystemController.Shutdown(force);
            return "Done.";
        }

        [HttpGet("restart")]
        public string Restart(bool force)
        {
            operatingSystemController.Restart(force);
            return "Done.";
        }

        [HttpGet("sleep")]
        public string Sleep()
        {
            operatingSystemController.Sleep();
            return "Done.";
        }

        [HttpGet("hibernate")]
        public string Hibernate()
        {
            operatingSystemController.Hibernate();
            return "Done.";
        }

        [HttpGet("lock")]
        public string Lock()
        {
            operatingSystemController.Lock();
            return "Done.";
        }
    }
}