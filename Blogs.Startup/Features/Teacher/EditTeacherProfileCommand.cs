using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teacher
{
    public class EditTeacherProfileCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string? NewEmail { get; set; }
        public string? NewPost { get; set; }
        public string? NewInstitute { get; set; }
    }

    public class EditTeacherProfileCommandHandler : IRequestHandler<EditTeacherProfileCommand, bool>
    {
        private BlogContext _blogContext;

        public EditTeacherProfileCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(EditTeacherProfileCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var teacher = await _blogContext.Teachers.FirstAsync(p => p.PersonId == request.PersonId);

            if (request.NewPassword != null) person.Password = request.NewPassword;
            if (request.NewPhoneNumber != null) person.PhoneNumber = request.NewPhoneNumber;
            if (request.NewEmail != null) person.Email = request.NewEmail;

            if (request.NewPost != null) teacher.Post = request.NewPost;
            if (request.NewInstitute != null) teacher.Institute = request.NewInstitute;

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
