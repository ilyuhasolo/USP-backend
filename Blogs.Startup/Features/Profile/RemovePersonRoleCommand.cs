using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Profile
{
    public class RemovePersonRoleCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public long RoleId { get; set; }
    }

    public class RemovePersonRoleCommandHandler : IRequestHandler<RemovePersonRoleCommand, bool>
    {
        private BlogContext _blogContext;

        public RemovePersonRoleCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(RemovePersonRoleCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People
                .Include(p => p.Roles)
                .FirstAsync(p => p.Id == request.PersonId);
            var role = await _blogContext.Roles.FirstAsync(r => r.Id == request.RoleId);

            person.Roles.Remove(role);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
