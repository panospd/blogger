using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.BlogUseCases
{
    public interface IBlogRepository
    {
        Task CreateAsync(Blog blog);
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(Guid id);
        void Update(Blog blog);
        Task CommitAsync();
    }
}
