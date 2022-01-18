using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teams
{
    public class RemovePersonFromTeamCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public long TeamId { get; set; }
    }

    public class RemovePersonFromTeamCommandHandler : IRequestHandler<RemovePersonFromTeamCommand, bool>
    {
        private BlogContext _blogContext;

        public RemovePersonFromTeamCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(RemovePersonFromTeamCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.Include(p => p.Teams).FirstAsync(p => p.Id == request.PersonId);
            var team = await _blogContext.Teams.Include(t => t.Lineups).FirstAsync(t => t.Id == request.TeamId);
            var lineup = team.Lineups.FirstOrDefault(x => x.PersonId == request.PersonId);

            if (lineup != null && lineup.Accepted == true)
                team.PeopleNumber--;

            person.Teams.Remove(team);
            

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
