using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class EditStudentProfileCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string? NewEmail { get; set; }
        public string? NewGroup { get; set; }
        public string? NewAbout { get; set; }
    }

    public class ChangeGroupCommandHandler : IRequestHandler<EditStudentProfileCommand, bool>
    {
        private BlogContext _blogContext;

        public ChangeGroupCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(EditStudentProfileCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var student = await _blogContext.Students.FirstAsync(p => p.PersonId == request.PersonId);

            if (request.NewPassword != null) person.Password = request.NewPassword;
            if (request.NewPhoneNumber != null) person.PhoneNumber = request.NewPhoneNumber;
            if (request.NewEmail != null) person.Email = request.NewEmail;

            if (request.NewGroup != null) student.Group = request.NewGroup;
            if (request.NewAbout != null) student.About = request.NewAbout;

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
