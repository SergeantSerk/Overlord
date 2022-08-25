using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Overlord.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatingSystemController : ControllerBase
    {
        public enum Action
        {
            Logoff,
            Shutdown,
            Restart,
            Sleep,
            Hibernate,
            Lock
        }

        private readonly ILogger<OperatingSystemController> _logger;
        private readonly IOperatingSystemController operatingSystemController;

        public OperatingSystemController(ILogger<OperatingSystemController> logger)
        {
            _logger = logger;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _logger.LogInformation($"OS is {nameof(OSPlatform.Windows)}, controller initialised with {nameof(WindowsController)}");
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

        [HttpGet]
        public string Get(Action action, bool force)
        {
            switch (action)
            {
                case Action.Logoff:
                    operatingSystemController.Logoff(force);
                    break;
                case Action.Shutdown:
                    operatingSystemController.Shutdown(force);
                    break;
                case Action.Restart:
                    operatingSystemController.Restart(force);
                    break;
                case Action.Sleep:
                    operatingSystemController.Sleep();
                    break;
                case Action.Hibernate:
                    operatingSystemController.Hibernate();
                    break;
                case Action.Lock:
                    operatingSystemController.Lock();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return "Done.";
        }
    }
}