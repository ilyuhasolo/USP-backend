using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blogs.Startup.Features.Person;

namespace Blogs.Startup.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("~/RegisterNewPerson")]
        public async Task<IActionResult> RegisterNewPerson(RegisterNewPersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("~/AuthorizePerson")]
        public async Task<IActionResult> AuthorizePerson(AuthorizePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request,cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
