using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetStudentInfoCommand : IRequest<Student?>
    {
        public long PersonId { get; set; }
    }

    public class GetStudentInfoCommandHandler : IRequestHandler<GetStudentInfoCommand, Student?>
    {
        private BlogContext _blogContext;

        public GetStudentInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Student?> Handle(GetStudentInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Students.FirstOrDefaultAsync(s => s.PersonId == request.PersonId);
        }
    }
}
