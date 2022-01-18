using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetRolesByPersonIdCommand : IRequest<IReadOnlyList<Role>>
    { 
        public long Id { get; set; } 
    }

    public class GetRolesByPersonIdCommandHandler : IRequestHandler<GetRolesByPersonIdCommand, IReadOnlyList<Role>>
    {
        private BlogContext _blogContext;

        public GetRolesByPersonIdCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Role>> Handle(GetRolesByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var person =  await _blogContext.People
                .Include(p => p.Roles)
                .FirstAsync(p => p.Id == request.Id);
            return person.Roles;
        }
    }
}
