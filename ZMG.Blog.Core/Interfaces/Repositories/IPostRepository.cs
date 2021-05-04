using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZMG.Blog.Core.Entities;

namespace ZMG.Blog.Core.Interfaces.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithCommentsAsync();
        Task<Post> GetWithCommentByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllByPostStateIdAsync(Guid stateId);
    }
}
