using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllTeachersCommand : IRequest<IReadOnlyList<Person>>
    {

    }

    public class GetAllTeachersCommandHandler : IRequestHandler<GetAllTeachersCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetAllTeachersCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetAllTeachersCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.People
                .Include(p => p.Teacher)
                .Include(p => p.Interests)
                .Where(p => p.Teacher != null)
                .ToListAsync();
        }
    }
}
