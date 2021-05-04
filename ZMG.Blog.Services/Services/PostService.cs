using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZMG.Blog.Core.Dtos;
using ZMG.Blog.Core.Entities;
using ZMG.Blog.Core.Interfaces.Repositories;
using ZMG.Blog.Core.Interfaces.Services;

namespace ZMG.Blog.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PostDto> Create(Post newPost)
        {
            await _repository.AddAsync(newPost);
            return _mapper.Map<PostDto>(newPost);
        }

        public async Task DeleteAsync(Post post)
        {
            await _repository.RemoveAsync(post);
        }

        public async Task<IEnumerable<PostDto>> GetAllWithCommentsAsync()
        {
            //var posts = await _repository.GetAllWithCommentsAsync();
            var userId1 = Guid.NewGuid().ToString();
            var roleId1 = Guid.NewGuid().ToString();
            var posts = new List<Post>
            {
                new Post
                {
                    Author = new User
                    {
                        Id = userId1,
                        Email = "jmhurtador@gmail.com",
                        FirstName = "Jorge",
                        LastName = "Hurtado",
                        UserRoles = new List<UserRole>
                        {
                            new UserRole
                            {
                                UserId = userId1,
                                RoleId = roleId1
                            }
                        }
                    },
                    Title = "Post 1",
                    Content = "First Blog  aldiugasd asidtadaj xñasjd pasfuyw iugr ñgkjsgñWUF WUEGFweugf WFUGwñefkh",
                },
                new Post
                {
                    Author = new User
                    {
                        Id = userId1,
                        Email = "jmhurtador@gmail.com",
                        FirstName = "Jorge",
                        LastName = "Hurtado",
                        UserRoles = new List<UserRole>
                        {
                            new UserRole
                            {
                                UserId = userId1,
                                RoleId = roleId1
                            }
                        }
                    },
                    Title = "Post 2",
                    Content = "Mi Blog akjas asd jhasd ashdñakus hdaskd ñdads lagdaysgdasd aksd akd asydflajsygd alsd",
                },
            };
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public Task<IEnumerable<PostDto>> GetPostByAuthorIdAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
