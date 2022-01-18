using Blogs.Core.Domain.Model;
using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Startup.Features.Teams
{
    public class CreateNewTeamCommand : IRequest<long>
    {
        public string TeamLeadPhoneNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Interests { get; set; }
        public List<string> VacantRoles { get; set; }
    }

    public class CreateNewTeamCommandHandler : IRequestHandler<CreateNewTeamCommand, long>
    {
        private BlogContext _blogContext;

        public CreateNewTeamCommandHandler(BlogContext blogContext) 
        {
            _blogContext = blogContext;
        }

        public async Task<long> Handle(CreateNewTeamCommand request, CancellationToken cancellationToken)
        {
            var interests = request.Interests
                .Select(i => _blogContext.Interests
                    .FirstOrDefault(interest => interest.InterestName == i))
                .Where(i => i != null)
                .ToList();
            var roles = request.VacantRoles
                .Select(r => _blogContext.Roles
                    .FirstOrDefault(role => role.RoleName == r))
                .Where(i => i != null)
                .ToList();

            var team = new Team()
            {
                Name = request.Name,
                Description = request.Description,
                Roles = roles is null ? new List<Role>() : roles,
                Interests = interests is null ? new List<Interest>() : interests,
                TeamLeadPhoneNumber = request.TeamLeadPhoneNumber
            };
            await _blogContext.Teams.AddAsync(team);
            await _blogContext.SaveChangesAsync();

            return _blogContext.Teams.First(t => t.Equals(team)).Id;
        }
    }
}
