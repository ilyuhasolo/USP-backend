using System.Text.Json.Serialization;

namespace Blogs.Core.Domain.Model
{
    public class Student
    {
        public long Id { get; set; }
        public string Group { get; set; }
        public string About { get; set; }

        [JsonIgnore]
        public long PersonId { get; set; }

        [JsonIgnore]
        public Person? Person { get; set; }
    }
}
