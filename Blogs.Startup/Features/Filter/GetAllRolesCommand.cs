using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Filter
{
    public class GetAllRolesCommand : IRequest<IReadOnlyList<Role>>
    {
    }

    public class GetAllRolesCommandHandler : IRequestHandler<GetAllRolesCommand, IReadOnlyList<Role>>
    {
        private BlogContext _blogContext;

        public GetAllRolesCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Role>> Handle(GetAllRolesCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.Roles.ToListAsync();
        }
    }
}
