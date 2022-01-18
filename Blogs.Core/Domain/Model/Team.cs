using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PeopleNumber { get; set; }
        public string TeamLeadPhoneNumber { get; set; }

        public List<Interest> Interests { get; set; }
        [JsonIgnore]
        public List<Person> People { get; set; }
        public List<Role> Roles { get; set; }
        public List<Lineup> Lineups { get; set; }

        public Team()
        {
            Interests = new List<Interest>();
            People = new List<Person>();
            Roles = new List<Role>();
            Lineups = new List<Lineup>();
        }
    }
}
