using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllEmployersCommand : IRequest<IReadOnlyList<Person>>
    {

    }

    public class GetAllEmployersCommandHandler : IRequestHandler<GetAllEmployersCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetAllEmployersCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetAllEmployersCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.People
                .Include(p => p.Employer)
                .Include(p => p.Interests)
                .Where(p => p.Employer != null)
                .ToListAsync();
        }
    }
}