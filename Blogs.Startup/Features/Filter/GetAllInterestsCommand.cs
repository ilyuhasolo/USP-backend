using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;
using Blogs.Core.Domain.Model;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllInterestsCommand : IRequest<IReadOnlyList<Interest>>
    {

    }

    public class GetAllInterestsCommandHandler : IRequestHandler<GetAllInterestsCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetAllInterestsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetAllInterestsCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Interests.ToListAsync();
        }
    }
}
