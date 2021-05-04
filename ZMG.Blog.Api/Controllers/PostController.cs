using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMG.Blog.Core.Dtos;
using ZMG.Blog.Core.Interfaces.Services;

namespace ZMG.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var musics = await _postService.GetAllWithCommentsAsync();
            return Ok(musics);
        }
    }
}
