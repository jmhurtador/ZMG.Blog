using System;
using System.Collections.Generic;

namespace ZMG.Blog.Core.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string CoverImagePath { get; set; }
        public Guid PostStateId { get; set; }
        public PostState State { get; set; }
        public IList<Comment> Comments { get; } = new List<Comment>();

    }
}