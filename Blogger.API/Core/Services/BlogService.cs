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

        public async Task CreateAsync(CreateBlogCommand command)
        {
            var blog = new Blog
            {
                Title = command.Title,
                Description = command.Description,
                Body = command.Body
            };

            await _blogRepository.CreateAsync(blog);
        }

        public async Task UpdateAsync(UpdateBlogCommand blogCommand)
        {
            var blogToUpdate = await _blogRepository.GetByIdAsync(blogCommand.Id);

            if (blogToUpdate == default)
            {
                throw new ArgumentNullException($"{nameof(blogToUpdate)} found to be null");
            }

            blogToUpdate.Title = blogCommand.Title;
            blogToUpdate.Description = blogCommand.Description;
            blogToUpdate.Body = blogCommand.Body;

            await _blogRepository.UpdateAsync(blogToUpdate);
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
