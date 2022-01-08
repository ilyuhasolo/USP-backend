using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teacher
{
    public class GetTeacherInfoCommand : IRequest<Core.Domain.Model.Teacher?>
    {
        public long PersonId { get; set; }
    }

    public class GetTeacherInfoCommandHandler : IRequestHandler<GetTeacherInfoCommand, Core.Domain.Model.Teacher?>
    {
        private BlogContext _blogContext;

        public GetTeacherInfoCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Core.Domain.Model.Teacher?> Handle(GetTeacherInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Teachers.FirstOrDefaultAsync(s => s.PersonId == request.PersonId);
        }
    }
}
