using Blogger.API.Api.Tags;
using System;
using System.Collections.Generic;

namespace Blogger.API.Api.Stories
{
    public class StoryDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public List<TagDTO> TagsDTO { get; set; }
    }
}