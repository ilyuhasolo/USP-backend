using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Employer
{
    public class EditEmployerProfileCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string? NewEmail { get; set; }
        public string? NewCompany { get; set; }
        public string? NewPresentation { get; set; }
    }

    public class EditEmployerProfileCommandHandler : IRequestHandler<EditEmployerProfileCommand, bool>
    {
        private BlogContext _blogContext;

        public EditEmployerProfileCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(EditEmployerProfileCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var employer = await _blogContext.Employers.FirstAsync(p => p.PersonId == request.PersonId);

            if (request.NewPassword != null) person.Password = request.NewPassword;
            if (request.NewPhoneNumber != null) person.PhoneNumber = request.NewPhoneNumber;
            if (request.NewEmail != null) person.Email = request.NewEmail;

            if (request.NewCompany != null) employer.Company = request.NewCompany;
            if (request.NewPresentation != null) employer.Presentation = request.NewPresentation;

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
