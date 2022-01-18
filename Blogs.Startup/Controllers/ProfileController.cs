using Blogs.Startup.Features.Profile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blogs.Core.Domain.Model;

namespace Blogs.Startup.Controllers
{
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Person

        [HttpGet]
        [Route("~/GetPersonInfo")]
        public async Task<Person> GetPersonInfo([FromQuery] GetPersonInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("~/AddInterestToPerson")]
        public async Task<IActionResult> AddInterestToPerson(AddInterestToPersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("~/AddRoleToPerson")]
        public async Task<IActionResult> AddRoleToPerson(AddRoleToPersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("~/GetRolesByPersonId")]
        public async Task<IReadOnlyList<Role>> GetRolesByPersonId([FromQuery] GetRolesByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetInterestsByPersonId")]
        public async Task<IReadOnlyList<Interest>> GetInterestsByPersonId([FromQuery] GetInterestsByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("~/GetTeamsByPersonId")]
        public async Task<IReadOnlyList<Team>> GetTeamsByPersonId([FromQuery] GetTeamsByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpDelete]
        [Route("~/DeletePerson")]
        public async Task<IActionResult> DeletePerson([FromQuery] DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete]
        [Route("~/RemovePersonInterest")]
        public async Task<IActionResult> RemovePersonInterest([FromQuery] RemovePersonInterestCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete]
        [Route("~/RemovePersonRole")]
        public async Task<IActionResult> RemovePersonRole([FromQuery] RemovePersonRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : NotFound();
        }

        #endregion
        #region Student

        [HttpGet]
        [Route("~/GetStudentInfo")]
        public async Task<Student> GetStudentInfo([FromQuery]GetStudentInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("~/EditStudentProfile")]
        public async Task<IActionResult> EditStudentProfile(EditStudentProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
        #region Teacher

        [HttpGet]
        [Route("~/GetTeacherInfo")]
        public async Task<Teacher> GetTeacherInfo([FromQuery] GetTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("~/EditTeacherProfile")]
        public async Task<IActionResult> EditTeacherProfile(EditTeacherProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
        #region Employer

        [HttpGet]
        [Route("~/GetEmployerInfo")]
        public async Task<Employer> GetEmployerInfo([FromQuery] GetEmployerInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("~/EditEmployerProfile")]
        public async Task<IActionResult> EditEmployerProfile(EditEmployerProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
    }
}