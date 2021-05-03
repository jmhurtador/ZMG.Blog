using System;

namespace ZMG.Blog.Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public bool Deleted { get; set; } = false;
    }
}