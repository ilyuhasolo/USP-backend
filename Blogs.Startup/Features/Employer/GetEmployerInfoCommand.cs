using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Employer
{
    public class GetEmployerInfoCommand : IRequest<Core.Domain.Model.Employer?>
    {
        public long PersonId { get; set; }
    }

    public class GetEmployerInfoCommandHandler : IRequestHandler<GetEmployerInfoCommand, Core.Domain.Model.Employer?>
    {
        private BlogContext _blogContext;

        public GetEmployerInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Core.Domain.Model.Employer?> Handle(GetEmployerInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Employers.FirstOrDefaultAsync(s => s.PersonId == request.PersonId);
        }
    }
}
