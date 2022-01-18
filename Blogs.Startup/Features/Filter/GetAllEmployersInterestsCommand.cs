using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllEmployersInterestsCommand : IRequest<IReadOnlyList<Interest>>
    {

    }

    public class GetAllEmployersInterestsCommandHandler : IRequestHandler<GetAllEmployersInterestsCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetAllEmployersInterestsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetAllEmployersInterestsCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Employer)
                .Include(p => p.Interests)
                .ToListAsync();

            return res
                .Where(p => p.Employer != null)
                .SelectMany(p => p.Interests)
                .Distinct()
                .ToList();
        }
    }
}
