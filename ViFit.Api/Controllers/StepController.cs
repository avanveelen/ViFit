using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViFit.Application;
using ViFit.Application.Steps;

namespace ViFit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : Controller
    {
        private readonly ICommandDispatcher commandDispatcher;

        public StepsController(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Add(AddStepRegistration command)
        {
            await this.commandDispatcher.Dispatch(command);
            return new AcceptedResult();
            //return new ConflictResult();
        }
    }
}