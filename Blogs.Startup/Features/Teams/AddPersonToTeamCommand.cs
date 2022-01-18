using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teams
{
    public class AddPersonToTeamCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public long TeamId { get; set; }
    }

    public class AddPersonToTeamCommandHandler : IRequestHandler<AddPersonToTeamCommand, bool>
    {
        private BlogContext _blogContext;

        public AddPersonToTeamCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(AddPersonToTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _blogContext.Teams.Include(t => t.Lineups).FirstAsync(t => t.Id == request.TeamId);
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);

            team.PeopleNumber++;

            var lineup = team.Lineups.FirstOrDefault(l => l.PersonId == request.PersonId);

            if (lineup == null)
                team.Lineups.Add(new Core.Domain.Model.Lineup
                {
                    PersonId = request.PersonId,
                    Person = person,

                    TeamId = request.TeamId,
                    Team = team,

                    Accepted = false
                });
            else
                lineup.Accepted = true;

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
