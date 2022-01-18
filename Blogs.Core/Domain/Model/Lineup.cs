using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Lineup
    {
        [JsonIgnore]
        public long PersonId { get; set; }
        public Person? Person { get; set; }

        [JsonIgnore]
        public long TeamId { get; set; }
        [JsonIgnore]
        public Team? Team { get; set; }

        public bool Accepted { get; set; }
    }
}
