using MediatR;
using Blogs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Blogs.Core.Domain.Model;

namespace Blogs.Startup.Features.Profile
{
    public class GetPersonInfoCommand : IRequest<Person?>
    {
        public long Id { get; set; }
    }

    public class GetPersonInfoHandler : IRequestHandler<GetPersonInfoCommand, Person?>
    {
        private readonly BlogContext _blogContext;

        public GetPersonInfoHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<Core.Domain.Model.Person?> Handle(GetPersonInfoCommand request, CancellationToken cancellationToken)
        {
            return await _blogContext.People.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
