using Blogs.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Profile
{
    public class RemovePersonInterestCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public long InterestId { get; set; }
    }

    public class RemovePersonInterestCommandHandler : IRequestHandler<RemovePersonInterestCommand, bool>
    {
        private BlogContext _blogContext;

        public RemovePersonInterestCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(RemovePersonInterestCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People
                .Include(p => p.Interests)
                .FirstAsync(p => p.Id == request.PersonId);
            var interest = await _blogContext.Interests.FirstAsync(i => i.Id == request.InterestId);

            person.Interests.Remove(interest);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
