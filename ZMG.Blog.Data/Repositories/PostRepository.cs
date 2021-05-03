using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZMG.Blog.Core.Interfaces.Repositories;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private ZmgBlogDbContext ZmgBlogDbContext
        {
            get { return _context as ZmgBlogDbContext; }
        }

        public PostRepository(ZmgBlogDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Post>> GetAllWithCommentsAsync()
        {
            return await ZmgBlogDbContext.Posts
                .Include(m => m.Comments)
                .ToListAsync();
        }

        public async Task<Post> GetWithCommentByIdAsync(int id)
        {
            return await ZmgBlogDbContext.Posts
                .Include(m => m.Comments)
                .SingleOrDefaultAsync(m => m.Id.Equals(id));
        }

        public async Task<IEnumerable<Post>> GetAllByPostStateIdAsync(Guid stateId)
        {
            return await ZmgBlogDbContext.Posts
                .Where(p => p.PostStateId.Equals(stateId))
                .ToListAsync();
        }
    }
}
