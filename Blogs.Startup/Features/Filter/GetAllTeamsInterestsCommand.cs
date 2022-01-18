using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllTeamsInterestsCommand : IRequest<IReadOnlyList<Interest>>
    {

    }

    public class GetAllTeamsInterestsCommandHandler : IRequestHandler<GetAllTeamsInterestsCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetAllTeamsInterestsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetAllTeamsInterestsCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.Teams
                .Include(t => t.Interests)
                .ToListAsync();

            return res
                .SelectMany(t => t.Interests)
                .Distinct()
                .ToList();
        }
    }
}
