using Blogs.Startup.Features.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Startup.Controllers
{
    [Authorize]
    public class FilterController : Controller
    {
        private readonly IMediator _mediator;

        public FilterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("~/GetAllTeamsNames")]
        public async Task<IActionResult> GetAllTeamsNames(GetAllTeamsNamesCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetAllRoles")]
        public async Task<IActionResult> GetAllRoles(GetAllRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetFilteredTeams")]
        public async Task<IActionResult> GetFilteredTeams(GetFilteredTeamsCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetFilteredTeachers")]
        public async Task<IActionResult> GetFilteredTeachers(GetFilteredTeachersCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetFilteredEmployers")]
        public async Task<IActionResult> GetFilteredEmployers(GetFilteredEmployersCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetAllEmployersInterests")]
        public async Task<IActionResult> GetAllEmployersInterests(GetAllEmployersInterestsCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetAllTeachersInterests")]
        public async Task<IActionResult> GetAllTeachersInterests(GetAllTeachersInterestsCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetAllTeamsInterests")]
        public async Task<IActionResult> GetAllTeamsInterests(GetAllTeamsInterestsCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("~/GetAllStudentsInterests")]
        public async Task<IActionResult> GetAllStudentsInterests(GetAllStudentsInterestsCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
