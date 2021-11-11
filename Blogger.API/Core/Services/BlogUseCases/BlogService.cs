using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.BlogUseCases
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
            await _blogRepository.CommitAsync();
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

            _blogRepository.Update(blogToUpdate);
            await _blogRepository.CommitAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(Guid id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var blogToSoftDelete = await _blogRepository.GetByIdAsync(id);

            if (blogToSoftDelete == default)
                throw new ArgumentNullException(nameof(blogToSoftDelete));
           
            blogToSoftDelete.IsDeleted = true;

            _blogRepository.Update(blogToSoftDelete);

            await _blogRepository.CommitAsync();
        }
    }
}
