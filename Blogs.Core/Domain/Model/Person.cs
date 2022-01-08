using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public List<Interest> Interests { get; set; }
        public List<Role> Roles { get; set; }

        [JsonIgnore]
        public List<Team> Teams { get; set; }

        public Student? Student { get; set; }

        public Teacher? Teacher { get; set; }

        public Employer? Employer { get; set; }

        public Person()
        {
            Interests = new List<Interest>();
            Roles = new List<Role>();
            Teams = new List<Team>();
        }
    }
}
