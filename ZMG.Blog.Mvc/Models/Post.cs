using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZMG.Blog.Mvc.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Views { get; set; } = 0;
        public string Content { get; set; }
        public IList<Comment> Comments { get; } = new List<Comment>();
    }
}
