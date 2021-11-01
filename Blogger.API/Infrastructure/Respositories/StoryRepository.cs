using Blogger.API.Core;
using Blogger.API.Core.Services.StoryUseCases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{


    public class StoryRepository :IStoryRepository
    {
        private readonly BloggerContext _context;

        public StoryRepository(BloggerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Story>> GetAllAsync()
        {
            return await _context.Stories.ToListAsync();
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            return await _context.Stories.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
