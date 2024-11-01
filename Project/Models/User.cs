using System.Text.Json.Serialization;

namespace Project.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int IsDeleted { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
