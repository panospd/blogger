using Blogger.API.Api.Tags;
using Blogger.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Api.Stories
{
    public class Mapper
    {
        public StoryDTO StoryMapping(Story story)
        {
            return new StoryDTO
            {
                Id = story.Id,
                Title = story.Title,
                Message = story.Message,
                TagsDTO = story.Tags.Select(t => new TagDTO
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()
            };
        }
    }
}
