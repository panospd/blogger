using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Respositories
{
    public abstract class BaseRepository
    {
        protected BloggerContext DbContext { get; }

        protected BaseRepository(BloggerContext db)
        {
            DbContext = db;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
