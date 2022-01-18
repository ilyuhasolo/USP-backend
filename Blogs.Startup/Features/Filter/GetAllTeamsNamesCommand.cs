using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllTeamsNamesCommand : IRequest<IReadOnlyList<string>>
    {

    }

    public class GetAllTeamsNamesCommandHandler : IRequestHandler<GetAllTeamsNamesCommand, IReadOnlyList<string>>
    {
        private BlogContext _blogContext;

        public GetAllTeamsNamesCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<string>> Handle(GetAllTeamsNamesCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teams.Select(t => t.Name).ToListAsync();
        }
    }
}
