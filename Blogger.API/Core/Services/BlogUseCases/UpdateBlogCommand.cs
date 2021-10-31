using System;

namespace Blogger.API.Core.Services.BlogUseCases
{
    public class UpdateBlogCommand : BaseBlogCommand
    {
        public Guid Id { get; init; }
    }
}
