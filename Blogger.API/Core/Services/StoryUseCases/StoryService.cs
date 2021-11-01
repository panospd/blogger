using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public class StoryService
    {
        private readonly IStoryRepository _repository;

        public StoryService(IStoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Story>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
 
        }

        public async Task CreateAsync(CreateStoryCommand storyCommand)
        {
            var story = new Story
            {
                Title = storyCommand.Title,
                Message = storyCommand.Message
            };

            await _repository.CreateAsync(story);
        }

        public async Task UpdateAsync(UpdateStoryCommand updateStoryCommand)
        {
            var storyToUpdate = await _repository.GetByIdAsync(updateStoryCommand.Id);

            if (storyToUpdate == default)
                throw new ArgumentNullException(nameof(storyToUpdate));

            updateStoryCommand.Id = storyToUpdate.Id;
            updateStoryCommand.Title = storyToUpdate.Title;
            updateStoryCommand.Message = storyToUpdate.Message;

            await _repository.UpdateAsync(storyToUpdate);
        }
    }
}