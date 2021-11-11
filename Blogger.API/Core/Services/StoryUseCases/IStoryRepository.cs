using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public interface IStoryRepository
    {
        Task<List<Story>> GetAllAsync();
        Task<Story> GetByIdAsync(Guid id);
        Task CreateAsync(Story story);
        void Update(Story story);
        void Delete(Story story);
        Task CommitAsync();
    }
}
