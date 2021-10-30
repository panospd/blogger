using Blogger.API.Core;
using Blogger.API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _service;

        public BlogController(BlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogDto>>> GetAllAsync()
        {
            List<Blog> blogs = await _service.GetAllAsync();

            var blogDtos = blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Body = b.Body
            });

            return Ok(blogDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDto>> GetById(Guid id)
        {
            Blog blog = await _service.GetByIdAsync(id);

            var blogDto = new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Body = blog.Body
            };

            return Ok(blogDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BlogRequest blogRequest)
        {
            var blogCommand = new BlogCommand
            {
                Title = blogRequest.Title,
                Description = blogRequest.Description,
                Body = blogRequest.Body
            };

            await _service.CreateAsync(blogCommand);

            return Ok();
        }
    }
}
