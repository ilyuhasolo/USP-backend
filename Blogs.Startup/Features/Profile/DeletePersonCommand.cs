using MediatR;
using Microsoft.EntityFrameworkCore;
using Blogs.Infrastructure.Database;

namespace Blogs.Startup.Features.Profile
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private BlogContext _blogContext;

        public DeletePersonCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _blogContext.People.FirstOrDefaultAsync(p => p.Id == request.Id);
            _blogContext.People.Remove(person);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
