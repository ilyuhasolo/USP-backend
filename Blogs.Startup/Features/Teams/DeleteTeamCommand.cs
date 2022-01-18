using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Teams
{
    public class DeleteTeamCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private BlogContext _blogContext;

        public DeleteTeamCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _blogContext.Teams.FirstOrDefaultAsync(t => t.Id == request.Id);
            _blogContext.Teams.Remove(team);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
