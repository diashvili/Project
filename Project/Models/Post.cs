namespace Project.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int IsDeleted { get; set; }
        public User User { get; set; } = null!;
    }
}
