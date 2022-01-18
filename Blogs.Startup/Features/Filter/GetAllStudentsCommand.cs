using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllStudentsCommand : IRequest<IReadOnlyList<Person>>
    {

    }

    public class GetAllStudentsCommandHandler : IRequestHandler<GetAllStudentsCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetAllStudentsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetAllStudentsCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.People
                .Include(p => p.Student)
                .Where(p => p.Student != null)
                .ToListAsync();
        }
    }
}
