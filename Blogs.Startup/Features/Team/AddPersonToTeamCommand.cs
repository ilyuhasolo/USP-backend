using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Team
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
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var team = await _blogContext.Teams.FirstAsync(t => t.Id == request.TeamId);

            team.People.Add(person);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
