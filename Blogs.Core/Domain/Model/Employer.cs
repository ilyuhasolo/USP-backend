using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Employer
    {
        public long Id { get; set; }
        public string Company { get; set; }
        public string Presentation { get; set; }

        [JsonIgnore]
        public long PersonId { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }
    }
}
