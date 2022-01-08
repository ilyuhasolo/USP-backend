using Blogs.Startup.Features.Person;
using Blogs.Startup.Features.Student;
using Blogs.Startup.Features.Teacher;
using Blogs.Startup.Features.Employer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Startup.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Person

        [HttpGet]
        [Route("~/GetPersonInfo")]
        public async Task<IActionResult> GetPersonInfo(GetPersonInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is null ? NotFound("¬ведено неверное им€ пользовател€") : Ok(result);
        }

        [HttpPost]
        [Route("~/AddInterestToPerson")]
        public async Task<IActionResult> AddInterestToPerson(AddInterestToPersonCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        #endregion
        #region Student

        [Authorize(Roles = "Student")]
        [HttpGet]
        [Route("~/GetStudentInfo")]
        public async Task<IActionResult> GetStudentInfo(GetStudentInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [Authorize(Roles = "Student")]
        [HttpPut]
        [Route("~/EditStudentProfile")]
        public async Task<IActionResult> EditStudentProfile(EditStudentProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
        #region Teacher

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        [Route("~/GetTeacherInfo")]
        public async Task<IActionResult> GetTeacherInfo(GetTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut]
        [Route("~/EditTeacherProfile")]
        public async Task<IActionResult> EditTeacherProfile(EditTeacherProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
        #region Employer

        [Authorize(Roles = "Employer")]
        [HttpGet]
        [Route("~/GetEmployerInfo")]
        public async Task<IActionResult> GetEmployerInfo(GetEmployerInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [Authorize(Roles = "Employer")]
        [HttpPut]
        [Route("~/EditEmployerProfile")]
        public async Task<IActionResult> EditEmployerProfile(EditEmployerProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        #endregion
    }
}