using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Teacher
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Post { get; set; }
        public string Institute { get; set; }

        [JsonIgnore]
        public long PersonId { get; set; }

        [JsonIgnore]
        public Person Person { get; set; }
    }
}
