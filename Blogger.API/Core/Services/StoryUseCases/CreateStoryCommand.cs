
using Blogger.API.Api.Tags;
using System.Collections.Generic;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public class CreateStoryCommand
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public List<CreateTagCommand> TagsCommand { get; set; }
    }
}
