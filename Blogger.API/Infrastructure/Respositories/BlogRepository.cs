using Blogger.API.Core;
using Blogger.API.Core.Services.BlogUseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BloggerContext _dbContext;

        public BlogRepository(BloggerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public Task<Blog> GetByIdAsync(Guid id)
        {
            return _dbContext.Blogs.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Blog blogToUpdate)
        {
            _dbContext.Blogs.Update(blogToUpdate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
