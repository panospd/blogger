using System;

namespace Blogger.API.Core.Services
{
    public class UpdateBlogCommand : BaseBlogCommand
    {
        public Guid Id { get; init; }
    }
}
