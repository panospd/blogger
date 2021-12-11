using Blogger.API.Core;
using Blogger.API.Core.Services.StoryUseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly BloggerContext _context;
        public StoryRepository(BloggerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
        }

        public void Delete(Story story)
        {
             _context.Stories.Remove(story);
        }

        public async Task<List<Story>> GetAllAsync()
        {
            return await _context.Stories.Include(s => s.Tags).ToListAsync();
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            return await _context.Stories.Include(s=>s.Tags).SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Update(Story story)
        {
            _context.Stories.Update(story);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
