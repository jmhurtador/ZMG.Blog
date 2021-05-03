using System.Collections.Generic;
using System.Threading.Tasks;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllWithCommentsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>> GetPostByAuthorIdAsync(int authorId);
        Task<Post> Create(Post newPost);
        Task UpdateAsync(Post postToBeUpdated, Post post);
        Task DeleteAsync(Post post);
    }
}
