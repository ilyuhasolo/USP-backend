using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetFilteredStudentsCommand : IRequest<IReadOnlyList<Person>>
    {
        public string? Role { get; set; }
        public string? Name { get; set; }
        public List<string>? StudentInterests { get; set; }
    }

    public class GetFilteredStudentsCommandHandler : IRequestHandler<GetFilteredStudentsCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetFilteredStudentsCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetFilteredStudentsCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Interests)
                .Include(p => p.Roles)
                .Include(p => p.Student)
                .ToListAsync();
            return res
                .Where(p => p.Student != null)
                .Where(p => request.Name == null || p.Name == request.Name)
                .Where(p => request.Role == null || p.Roles.Select(r => r.RoleName).Contains(request.Role))
                .Where(p => request.StudentInterests == null || p.Interests
                    .Select(i => i.InterestName)
                    .Intersect(request.StudentInterests)
                    .Count() == request.StudentInterests.Count)
                .ToList();
        }
    }
}
