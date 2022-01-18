using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetFilteredEmployersCommand : IRequest<IReadOnlyList<Person>>
    {
        public string? Company { get; set; }
        public List<string>? EmployerInterests { get; set; }
    }

    public class GetFilteredEmployersCommandHandler : IRequestHandler<GetFilteredEmployersCommand, IReadOnlyList<Person>>
    {
        private BlogContext _blogContext;

        public GetFilteredEmployersCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetFilteredEmployersCommand request, CancellationToken cancellationToken)
        {
            var res = await _blogContext.People
                .Include(p => p.Interests)
                .Include(p => p.Employer)
                .ToListAsync();
            return res
                .Where(p => p.Employer != null)
                .Where(p => request.Company == null || p.Employer.Company == request.Company)
                .Where(p => request.EmployerInterests == null || p.Interests
                    .Select(i => i.InterestName)
                    .Intersect(request.EmployerInterests)
                    .Count() == request.EmployerInterests.Count)
                .ToList();
        }
    }
}
