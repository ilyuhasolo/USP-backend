using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetEmployerInfoCommand : IRequest<Employer>
    {
        public long PersonId { get; set; }
    }

    public class GetEmployerInfoCommandHandler : IRequestHandler<GetEmployerInfoCommand, Employer>
    {
        private BlogContext _blogContext;

        public GetEmployerInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Employer> Handle(GetEmployerInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Employers.FirstAsync(s => s.PersonId == request.PersonId);
        }
    }
}
