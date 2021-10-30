using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services
{
    public interface IBlogRepository
    {
        Task CreateAsync(Blog blog);
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(Guid id);
    }
}
