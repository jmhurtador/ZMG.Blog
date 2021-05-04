using System.Collections.Generic;
using System.Threading.Tasks;
using ZMG.Blog.Core.Dtos;

namespace ZMG.Blog.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllWithCommentsAsync();
        //Task<PostDto> GetPostByIdAsync(int id);
        //Task<IEnumerable<PostDto>> GetPostByAuthorIdAsync(int authorId);
        //Task<PostDto> Create(Post newPost);
        //Task UpdateAsync(Post postToBeUpdated, Post post);
        //Task DeleteAsync(Post post);
    }
}
