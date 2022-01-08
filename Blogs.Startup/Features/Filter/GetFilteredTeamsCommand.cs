using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetFilteredTeamsCommand : IRequest<IReadOnlyList<Core.Domain.Model.Team>>
    {
        public List<string>? TeamInterests { get; set; }
        public string? TeamName { get; set; }
        public List<string>? TeamVacantRoles { get; set; }
    }

    public class GetFilteredTeamsCommandHandler : IRequestHandler<GetFilteredTeamsCommand, IReadOnlyList<Core.Domain.Model.Team>>
    {
        private BlogContext _blogContext;

        public GetFilteredTeamsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Core.Domain.Model.Team>> Handle(GetFilteredTeamsCommand request, CancellationToken cancellationToken)
        {
            var res =  await _blogContext.Teams
                .Include(t => t.Interests)
                .Include(t => t.Roles)
                .ToListAsync();
            return res
                .Where(t => request.TeamName == null || t.Name == request.TeamName)
                .Where(t => request.TeamInterests == null || t.Interests
                    .Select(i => i.InterestName)
                    .Intersect(request.TeamInterests)
                    .Count() == request.TeamInterests.Count)
                .Where(t => request.TeamVacantRoles == null || t.Roles
                    .Select(r => r.RoleName)
                    .Intersect(request.TeamVacantRoles)
                    .Count() == request.TeamVacantRoles.Count)
                .ToList();
        }
    }
}
