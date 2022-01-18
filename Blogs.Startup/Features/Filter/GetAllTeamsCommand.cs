using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllTeamsCommand : IRequest<IReadOnlyList<Team>>
    {

    }

    public class GetAllTeamsCommandHandler : IRequestHandler<GetAllTeamsCommand, IReadOnlyList<Team>>
    {
        private BlogContext _blogContext;

        public GetAllTeamsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Team>> Handle(GetAllTeamsCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teams
                .Include(t => t.Interests)
                .Include(t => t.Roles)
                .ToListAsync();
        }
    }
}
