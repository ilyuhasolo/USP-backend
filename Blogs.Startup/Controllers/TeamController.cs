using Blogs.Startup.Features.Teams;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blogs.Core.Domain.Model;

namespace Blogs.Startup.Controllers
{
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("~/CreateNewTeam")]
        public async Task<long> CreateNewTeam(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetTeamById")]
        public async Task<Team> GetTeamById([FromQuery] GetTeamByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPut]
        [Route("~/AddPersonToTeam")]
        public async Task<IActionResult> AddPersonToTeam([FromQuery] AddPersonToTeamCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        [Route("~/SendRequestToTeam")]
        public async Task<IActionResult> SendRequestToTeam([FromQuery] SendRequestToTeamCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("~/RemovePersonFromTeam")]
        public async Task<IActionResult> RemovePersonFromTeam([FromQuery] RemovePersonFromTeamCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete]
        [Route("~/DeleteTeam")]
        public async Task<IActionResult> DeleteTeam([FromQuery] DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : NotFound();
        }
    }
}