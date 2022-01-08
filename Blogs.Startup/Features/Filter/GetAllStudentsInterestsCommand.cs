using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllStudentsInterestsCommand : IRequest<IReadOnlyList<Interest>>
    {

    }

    public class GetAllStudentsInterestsCommandHandler : IRequestHandler<GetAllStudentsInterestsCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetAllStudentsInterestsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetAllStudentsInterestsCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Student)
                .Include(p => p.Interests)
                .ToListAsync();

            return res
                .Where(p => p.Student != null)
                .SelectMany(p => p.Interests)
                .ToList();
        }
    }
}
