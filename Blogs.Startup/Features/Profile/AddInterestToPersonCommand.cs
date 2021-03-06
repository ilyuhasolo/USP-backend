using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Profile
{
    public class AddInterestToPersonCommand : IRequest<bool>
    {
        public long PersonId { get; set; }
        public string Interest { get; set; }
    }

    public class AddInterestToPersonCommandHandler : IRequestHandler<AddInterestToPersonCommand, bool>
    {
        private BlogContext _blogContext;

        public AddInterestToPersonCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(AddInterestToPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstAsync(p => p.Id == request.PersonId);
            var interest = await _blogContext.Interests.FirstOrDefaultAsync(i => i.InterestName == request.Interest);

            if (interest != null)
                person.Interests.Add(interest);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
