using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Team
{
    public class GetTeamByIdCommand : IRequest<Core.Domain.Model.Team?>
    {
        public long TeamId { get; set; }
    }

    public class GetTeamByIdCommandHandler : IRequestHandler<GetTeamByIdCommand, Core.Domain.Model.Team?>
    {
        private BlogContext _blogContext;

        public GetTeamByIdCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Core.Domain.Model.Team?> Handle(GetTeamByIdCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teams.Include(t => t.People).FirstAsync(t => t.Id == request.TeamId);
        }
    }
}

