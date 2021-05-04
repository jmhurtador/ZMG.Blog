using System;

namespace ZMG.Blog.Core.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
