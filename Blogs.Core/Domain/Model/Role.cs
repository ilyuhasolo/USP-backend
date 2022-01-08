using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]
        public List<Person> People { get; set; }

        [JsonIgnore]
        public List<Team> Teams { get; set; }

        public Role()
        {
            People = new List<Person>();
            Teams = new List<Team>();
        }
    }
}
