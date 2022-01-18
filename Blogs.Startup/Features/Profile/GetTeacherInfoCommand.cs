using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetTeacherInfoCommand : IRequest<Teacher?>
    {
        public long PersonId { get; set; }
    }

    public class GetTeacherInfoCommandHandler : IRequestHandler<GetTeacherInfoCommand, Teacher?>
    {
        private BlogContext _blogContext;

        public GetTeacherInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Teacher?> Handle(GetTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teachers.FirstOrDefaultAsync(s => s.PersonId == request.PersonId);
        }
    }
}
