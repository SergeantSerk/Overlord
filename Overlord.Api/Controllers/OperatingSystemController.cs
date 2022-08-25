using Microsoft.AspNetCore.Mvc;

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
            operatingSystemController = new WindowsController();
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