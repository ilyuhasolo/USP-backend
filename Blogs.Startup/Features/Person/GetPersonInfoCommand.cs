using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blogs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Person
{
    public class GetPersonInfoCommand : IRequest<Core.Domain.Model.Person?>
    {
        [FromQuery]
        public long Id { get; set; }
    }

    public class GetPersonInfoHandler : IRequestHandler<GetPersonInfoCommand, Core.Domain.Model.Person?>
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
