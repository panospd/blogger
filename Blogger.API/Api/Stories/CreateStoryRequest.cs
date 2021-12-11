using Blogger.API.Api.Tags;
using System.Collections.Generic;

namespace Blogger.API.Api.Stories
{
    public class CreateStoryRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public List<CreateTagRequest> TagsRequest { get; set; }
    }
}