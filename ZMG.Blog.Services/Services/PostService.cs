using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZMG.Blog.Core.Interfaces.Repositories;
using ZMG.Blog.Core.Interfaces.Services;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<Post> Create(Post newPost)
        {
            await _repository.AddAsync(newPost);
            return newPost;
        }

        public async Task DeleteAsync(Post post)
        {
            await _repository.RemoveAsync(post);
        }

        public async Task<IEnumerable<Post>> GetAllWithCommentsAsync()
        {
            return await _repository.GetAllWithCommentsAsync();
        }

        public Task<IEnumerable<Post>> GetPostByAuthorIdAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
