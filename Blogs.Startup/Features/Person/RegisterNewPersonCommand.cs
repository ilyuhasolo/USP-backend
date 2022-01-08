using Blogs.Infrastructure.Database;
using MediatR;

namespace Blogs.Startup.Features.Person
{
    public class RegisterNewPersonCommand : IRequest<bool>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
        public string? Group { get; set; }
        public string? About { get; set; }
        public string? Company { get; set; }
        public string? Presentation { get; set; }
        public string? Post { get; set; }
        public string? Institute { get; set; }
    }

    public class RegisterNewPersonHandler : IRequestHandler<RegisterNewPersonCommand, bool>
    {
        private BlogContext _blogContext;

        public RegisterNewPersonHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(RegisterNewPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Core.Domain.Model.Person()
            {
                Login = request.Login,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            };
            await _blogContext.People.AddAsync(person);

            AddRoleToBase(request, person);

            var result = await _blogContext.SaveChangesAsync();
            return result > 0;
        }

        private async void AddRoleToBase(RegisterNewPersonCommand request, Core.Domain.Model.Person person)
        {
            switch (request.Role)
            {
                case "Student":
                    var student = new Core.Domain.Model.Student()
                    {
                        Group = request.Group,
                        About = request.About,
                        Person = person
                    };
                    await _blogContext.Students.AddAsync(student);
                    break;
                case "Teacher":
                    var teacher = new Core.Domain.Model.Teacher()
                    {
                        Post = request.Post,
                        Institute = request.Institute,
                        Person = person
                    };
                    await _blogContext.Teachers.AddAsync(teacher);
                    break;
                case "Employer":
                    var employer = new Core.Domain.Model.Employer()
                    {
                        Company = request.Company,
                        Presentation = request.Presentation,
                        Person = person
                    };
                    await _blogContext.Employers.AddAsync(employer);
                    break;
            }
        }
    }
}
