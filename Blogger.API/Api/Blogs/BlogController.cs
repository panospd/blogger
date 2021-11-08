using Blogger.API.Core;
using Blogger.API.Core.Services.BlogUseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Api.Blogs
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
            var blogs = await _service.GetAllAsync();

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
        public async Task<ActionResult> Create([FromBody] CreateBlogRequest createBlogRequest)
        {
            var blogCommand = new CreateBlogCommand
            {
                Title = createBlogRequest.Title,
                Description = createBlogRequest.Description,
                Body = createBlogRequest.Body
            };

            await _service.CreateAsync(blogCommand);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateBlogRequest updateBlogRequest)
        {
            var blogCommand = new UpdateBlogCommand
            {
                Id = updateBlogRequest.Id,
                Title = updateBlogRequest.Title,
                Description = updateBlogRequest.Description,
                Body = updateBlogRequest.Body
            };

            await _service.UpdateAsync(blogCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
