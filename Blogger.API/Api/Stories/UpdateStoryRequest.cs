using System;

namespace Blogger.API.Api.Stories
{
    public class UpdateStoryRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
