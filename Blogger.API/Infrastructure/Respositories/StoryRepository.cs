using Blogger.API.Core;
using Blogger.API.Core.Services.StoryUseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{
    public class StoryRepository : BaseRepository, IStoryRepository
    {
        public StoryRepository(BloggerContext context)
            :base(context)
        {
        }

        public async Task CreateAsync(Story story)
        {
            await DbContext.Stories.AddAsync(story);
        }

        public void Delete(Story story)
        {
            DbContext.Stories.Remove(story);
        }

        public async Task<List<Story>> GetAllAsync()
        {
            return await DbContext.Stories.ToListAsync();
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            return await DbContext.Stories.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Update(Story story)
        {
            DbContext.Stories.Update(story);
        }
    }
}
