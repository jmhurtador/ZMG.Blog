namespace ZMG.Blog.Core.Models
{
    public class Comment
    {
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public bool IsAdmin { get; set; } = false;
        public DateTime PubDate { get; set; } = DateTime.UtcNow;
    }
}