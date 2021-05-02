using System;

namespace ZMG.Blog.Data
{
    public class ZmgBlogDbContext : DbContext
    {
        public ZmgBlogDbContext(DbContextOptions<ZmgBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }
    }
}
