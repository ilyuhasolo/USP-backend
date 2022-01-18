using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blogs.Startup.Features.Account;

namespace Blogs.Startup.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
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
            return result ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("~/AuthorizePerson")]
        public async Task<AuthResponse> AuthorizePerson(AuthorizePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result;
        }
    }
}