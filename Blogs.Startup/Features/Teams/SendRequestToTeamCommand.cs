using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teams
{
    public class SendRequestToTeamCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public long TeamId { get; set; }
    }

    public class SendRequestToTeamCommandHandler : IRequestHandler<SendRequestToTeamCommand, bool>
    {
        private BlogContext _blogContext;

        public SendRequestToTeamCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(SendRequestToTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _blogContext.Teams.FirstAsync(t => t.Id == request.TeamId);
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);

            team.Lineups.Add(new Lineup
            {
                PersonId = request.PersonId,
                Person = person,

                TeamId = request.TeamId,
                Team = team,

                Accepted = false
            });

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
