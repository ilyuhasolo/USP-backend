using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetFilteredTeachersCommand : IRequest<IReadOnlyList<Person>>
    {
        public string? Post { get; set; }
        public string? Name {get; set;}
        public List<string>? TeacherInterests { get; set; }
    }

    public class GetFilteredTeachersCommandHandler : IRequestHandler<GetFilteredTeachersCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetFilteredTeachersCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetFilteredTeachersCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Interests)
                .Include(p => p.Teacher)
                .ToListAsync();
            return res
                .Where(p => p.Teacher != null)
                .Where(p => request.Name == null || p.Name == request.Name)
                .Where(p => request.Post == null || p.Teacher.Post == request.Post)
                .Where(p => request.TeacherInterests == null || p.Interests
                    .Select(i => i.InterestName)
                    .Intersect(request.TeacherInterests)
                    .Count() == request.TeacherInterests.Count)
                .ToList();
        }
    }
}
