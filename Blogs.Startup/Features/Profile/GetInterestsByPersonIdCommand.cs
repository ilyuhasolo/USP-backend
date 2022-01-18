using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class GetInterestsByPersonIdCommand : IRequest<IReadOnlyList<Interest>>
    {
        public long Id { get; set; }
    }

    public class GetInterestsByPersonIdCommandHandler : IRequestHandler<GetInterestsByPersonIdCommand, IReadOnlyList<Interest>>
    {
        private BlogContext _blogContext;

        public GetInterestsByPersonIdCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IReadOnlyList<Interest>> Handle(GetInterestsByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People
                .Include(p => p.Interests)
                .FirstAsync(p => p.Id == request.Id);
            return person.Interests;
        }
    }
}
