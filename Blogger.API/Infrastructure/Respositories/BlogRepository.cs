using Blogger.API.Core;
using Blogger.API.Core.Services.BlogUseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public BlogRepository(BloggerContext context) 
            : base(context)
        {
        }

        public async Task CreateAsync(Blog blog)
        {
            await DbContext.Blogs.AddAsync(blog);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await DbContext.Blogs
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public Task<Blog> GetByIdAsync(Guid id)
        {
            return DbContext.Blogs.SingleOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }

        public void Update(Blog blog)
        {
            DbContext.Blogs.Update(blog);
        }
    }
}
