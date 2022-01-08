using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Interest
    {
        public long Id { get; set; }
        public string InterestName { get; set; }

        [JsonIgnore]
        public List<Person> People { get; set; }

        [JsonIgnore]
        public List<Team> Teams { get; set; }

        public Interest()
        {
            People = new List<Person>();
            Teams = new List<Team>();
        }
    }
}
