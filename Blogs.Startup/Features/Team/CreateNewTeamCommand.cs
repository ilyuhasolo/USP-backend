using Blogs.Infrastructure.Database;
using MediatR;

namespace Blogs.Startup.Features.Team
{
    public class CreateNewTeamCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateNewTeamCommandHandler : IRequestHandler<CreateNewTeamCommand, bool>
    {
        private BlogContext _blogContext;

        public CreateNewTeamCommandHandler(BlogContext blogContext) 
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Handle(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Core.Domain.Model.Team()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _blogContext.Teams.AddAsync(team);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
