using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public class CreateStoryCommand
    {
        public string Title { get; set; }
        public string Message { get; set; }

    }
}
