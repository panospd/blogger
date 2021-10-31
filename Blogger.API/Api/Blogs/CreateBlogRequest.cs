namespace Blogger.API.Api.Blogs
{
    public class CreateBlogRequest
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string Body { get; init; }
    }
}
