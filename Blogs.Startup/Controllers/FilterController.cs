using Blogs.Startup.Features.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Blogs.Core.Domain.Model;

namespace Blogs.Startup.Controllers
{
    [ApiController]
    [Authorize]
    public class FilterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/GetAllTeamsNames")]
        public async Task<IReadOnlyList<string>> GetAllTeamsNames(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeamsNamesCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllRoles")]
        public async Task<IReadOnlyList<Role>> GetAllRoles(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllRolesCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllInterests")]
        public async Task<IReadOnlyList<Interest>> GetAllInterests(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllInterestsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetFilteredTeams")]
        public async Task<IReadOnlyList<Team>> GetFilteredTeams(string filters, CancellationToken cancellationToken)
        {
            var request = JsonSerializer.Deserialize<GetFilteredTeamsCommand>(filters);
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetFilteredStudents")]
        public async Task<IReadOnlyList<Person>> GetFilteredStudents(string filters, CancellationToken cancellationToken)
        {
            var request = JsonSerializer.Deserialize<GetFilteredStudentsCommand>(filters);
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetFilteredTeachers")]
        public async Task<IReadOnlyList<Person>> GetFilteredTeachers(string filters, CancellationToken cancellationToken)
        {
            var request = JsonSerializer.Deserialize<GetFilteredTeachersCommand>(filters);
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetFilteredEmployers")]
        public async Task<IReadOnlyList<Person>> GetFilteredEmployers(string filters, CancellationToken cancellationToken)
        {
            var request = JsonSerializer.Deserialize<GetFilteredEmployersCommand>(filters);
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllEmployersInterests")]
        public async Task<IReadOnlyList<Interest>> GetAllEmployersInterests(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployersInterestsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllTeachersInterests")]
        public async Task<IReadOnlyList<Interest>> GetAllTeachersInterests(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeachersInterestsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllTeamsInterests")]
        public async Task<IReadOnlyList<Interest>> GetAllTeamsInterests(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeamsInterestsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllStudentsInterests")]
        public async Task<IReadOnlyList<Interest>> GetAllStudentsInterests(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllStudentsInterestsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllTeams")]
        public async Task<IReadOnlyList<Team>> GetAllTeams(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeamsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllStudents")]
        public async Task<IReadOnlyList<Person>> GetAllStudents(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllStudentsCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllTeachers")]
        public async Task<IReadOnlyList<Person>> GetAllTeachers(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllTeachersCommand(), cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetAllEmployers")]
        public async Task<IReadOnlyList<Person>> GetAllEmployers(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployersCommand(), cancellationToken);
            return result;
        }
    }
}