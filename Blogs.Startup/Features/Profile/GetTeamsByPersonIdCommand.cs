using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetTeamsByPersonIdCommand : IRequest<IReadOnlyList<Team>>
    {
        public long Id { get; set; }
    }

    public class GetTeamsByPersonIdCommandHandler : IRequestHandler<GetTeamsByPersonIdCommand, IReadOnlyList<Team>>
    {
        private BlogContext _blogContext;

        public GetTeamsByPersonIdCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Team>> Handle(GetTeamsByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var teams = await _blogContext.Teams
                .Include(t => t.Interests)
                .Include(t => t.Roles)
                .Include(t => t.Lineups)
                .Include(t => t.People)
                .Where(t => t.People
                    .Select(p => p.Id)
                    .Contains(request.Id))
                .ToListAsync();
            return teams;
        }
    }
}
