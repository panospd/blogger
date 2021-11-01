
using Blogger.API.Core.Services.StoryUseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Api.Stories
{
    [ApiController]
    [Route ("api/[controller]")]  
    public class StoryController : ControllerBase
    {
        private readonly StoryService _service;

        public StoryController(StoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoryDTO>>> GetAllAsync()
        {
            var stories = await _service.GetAllAsync();
            var storiesDTOS = stories.Select(s => new StoryDTO
            {
                Id = s.Id,
                Title = s.Title,
                Message = s.Message
            });
            return Ok(storiesDTOS);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoryDTO>> GetByIdAsync(Guid id)
        {
            var story = await _service.GetByIdAsync(id);
            var storyDTO = new StoryDTO
            {
                Id = story.Id,
                Title = story.Title,
                Message = story.Message
            };
            return Ok(storyDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateStoryRequest storyRequest)
        {
            var storyCommand = new CreateStoryCommand
            {
                Title = storyRequest.Title,
                Message = storyRequest.Message
            };

            await _service.CreateAsync(storyCommand);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateStoryRequest updateStoryRequest)
        {
            var storyCommand = new UpdateStoryCommand
            {
                Id = updateStoryRequest.Id,
                Title = updateStoryRequest.Title,
                Message = updateStoryRequest.Message
            };
            await _service.UpdateAsync(storyCommand);
            return Ok();
        }



    }
}
