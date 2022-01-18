using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teams
{
    public class GetTeamByIdCommand : IRequest<Team?>
    {
        public long TeamId { get; set; }
    }

    public class GetTeamByIdCommandHandler : IRequestHandler<GetTeamByIdCommand, Team?>
    {
        private BlogContext _blogContext;

        public GetTeamByIdCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Team?> Handle(GetTeamByIdCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teams
                .Include(t => t.Lineups)
                .FirstAsync(t => t.Id == request.TeamId);
        }
    }
}

