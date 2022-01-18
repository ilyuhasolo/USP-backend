using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Profile
{
    public class AddRoleToPersonCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public string Role { get; set; }
    }

    public class AddRoleToPersonCommandHandler : IRequestHandler<AddRoleToPersonCommand, bool>
    {
        private BlogContext _blogContext;

        public AddRoleToPersonCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(AddRoleToPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var role = await _blogContext.Roles.FirstOrDefaultAsync(i => i.RoleName == request.Role);

            if (role != null)
                person.Roles.Add(role);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
