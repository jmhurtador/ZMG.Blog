using System;

namespace ZMG.Blog.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;
        public Guid? AuthorId { get; set; }
        public User Author { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}