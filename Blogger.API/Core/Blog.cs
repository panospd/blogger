using System;

namespace Blogger.API.Core
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string User { get; set; }
    }
}
