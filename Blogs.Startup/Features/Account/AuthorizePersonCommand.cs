using Blogs.Infrastructure.Database;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blogs.Startup.Features.Account
{
    public class AuthorizePersonCommand : IRequest<AuthResponse?>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizePersonCommandHandler : IRequestHandler<AuthorizePersonCommand, AuthResponse?>
    {
        private BlogContext _blogContext;
        private string? role;

        public AuthorizePersonCommandHandler(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public Task<AuthResponse?> Handle(AuthorizePersonCommand request, CancellationToken cancellationToken)
        {
            var identity = GetIdentity(request);
            if (identity == null) return Task.FromResult<AuthResponse?>(null);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new AuthResponse()
            {
                AccessToken = encodedJwt,
                Id = identity.Name,
                Role = role
            };

            return Task.FromResult(response);
        }

        private ClaimsIdentity? GetIdentity(AuthorizePersonCommand request)
        {
            Core.Domain.Model.Person? person = _blogContext.People
                .FirstOrDefault(x => x.Name == request.Name && x.Password == request.Password);
            if (person != null)
            {
                var student = _blogContext.Students.FirstOrDefault(s => s.Person == person);
                var teacher = _blogContext.Teachers.FirstOrDefault(t => t.Person == person);
                role = student is null ? teacher is null ? "Employer" : "Teacher" : "Student";
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims, 
                    "Token", 
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }

    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
