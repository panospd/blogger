namespace Blogger.API.Core.Services
{
    public abstract class BaseBlogCommand
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string Body { get; init; }
    }
}
