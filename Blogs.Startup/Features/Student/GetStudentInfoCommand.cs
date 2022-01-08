using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Student
{
    public class GetStudentInfoCommand : IRequest<Core.Domain.Model.Student?>
    {
        public long PersonId { get; set; }
    }

    public class GetStudentInfoCommandHandler : IRequestHandler<GetStudentInfoCommand, Core.Domain.Model.Student?>
    {
        private BlogContext _blogContext;

        public GetStudentInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Core.Domain.Model.Student?> Handle(GetStudentInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Students.FirstOrDefaultAsync(s => s.PersonId == request.PersonId);
        }
    }
}
