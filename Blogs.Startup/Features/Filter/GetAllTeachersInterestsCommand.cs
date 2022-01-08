using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllTeachersInterestsCommand : IRequest<IReadOnlyList<Interest>>
    {

    }

    public class GetAllTeachersInterestsCommandHandler : IRequestHandler<GetAllTeachersInterestsCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetAllTeachersInterestsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetAllTeachersInterestsCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Teacher)
                .Include(p => p.Interests)
                .ToListAsync();

            return res
                .Where(p => p.Teacher != null)
                .SelectMany(p => p.Interests)
                .ToList();
        }
    }
}
