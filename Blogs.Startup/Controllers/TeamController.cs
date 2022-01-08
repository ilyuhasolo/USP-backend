using Blogs.Startup.Features.Team;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Startup.Controllers
{
    public class TeamController : Controller
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("~/CreateNewTeam")]
        public async Task<IActionResult> CreateNewTeam(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        [HttpGet]
        [Route("~/GetTeamById")]
        public async Task<IActionResult> GetTeamById(GetTeamByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("~/AddPersonToTeam")]
        public async Task<IActionResult> AddPersonToTeam(AddPersonToTeamCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}
