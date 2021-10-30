using Blogger.API.Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task CreateAsync(BlogCommand command)
        {
            var blog = new Blog
            {
                Title = command.Title,
                Description = command.Description,
                Body = command.Body
            };

            await _blogRepository.CreateAsync(blog);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public Task<Blog> GetByIdAsync(Guid id)
        {
            return _blogRepository.GetByIdAsync(id);
        }
    }
}
