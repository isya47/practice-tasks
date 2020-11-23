/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalceholderAPI.Models;

namespace PalceholderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = Storage.GetAll();
            return Ok(new
            {
                posts = posts.postsArray,
                count = posts.count
            });

        }
        
        
        [HttpPost]
        
        public IActionResult Post(NewPost post)
        {
            var postVar = new Posts {UserId = post.UserId, Id = post.Id, Title = post.Title, Body = post.Body};
            var isOk = Storage.Add(postVar);
            return Ok($"Added: {isOk}");
        }
        
        
        
    }
}

*/

