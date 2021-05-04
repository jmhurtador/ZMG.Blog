using System;
using System.Collections.Generic;

namespace ZMG.Blog.Core.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string CoverImagePath { get; set; }
        public IList<CommentDto> Comments { get; set; }
    }
}
