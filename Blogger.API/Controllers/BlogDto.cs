using System;

namespace Blogger.API.Controllers
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
