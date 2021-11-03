using System;

namespace Blogger.API.Api.Stories
{
    public class StoryDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}