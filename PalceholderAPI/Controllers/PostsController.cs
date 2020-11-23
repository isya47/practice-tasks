using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PalceholderAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    
    public class PostsController : ControllerBase
    {
       
        private readonly ILogger<PostsController> _logger;
        private readonly IPostsService _myPostsService;
        
        public PostsController(ILogger<PostsController> logger, IPostsService myPostService)
        {
            _logger = logger;
            _myPostsService = myPostService;
        }

        [HttpGet]
        public async Task<ActionResult<Post>> Get()
        {
            //var service = new PostsService();
           // var posts = await service.GetPosts();

           var posts = await _myPostsService.GetPosts();
           return Ok(
               posts
           );
           
        }
        
        [Route("{id?}")]
        public async Task<ActionResult<Post>> Get(int? id)
        {
            
            //var service = new PostsService();
            //var post = await service.GetPost(id);
            var post = await _myPostsService.GetPost(id);
            
            return Ok(
                post
            );
            
        }
        
        [Route("search")]
        public async Task<ActionResult<Post>> Search([FromQuery] string query)
        {
            
            //var service = new PostsService();
            //var post = await service.GetByQuery(query);
            var post = await _myPostsService.GetByQuery(query);
            foreach (var record in post)
            {
                _logger.LogInformation($"User {record.UserId} has made a post with ID {record.Id}");
            }

            return Ok(
                post
            );
            
        }

    }
}