using System;
using System.Collections.Generic;
using System.Linq;
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
                Message = storyCommand.Message,
                Tags = storyCommand.TagsCommand.Select(t => new Tag
                {
                    Name = t.Name
                }).ToList()
            };

            await _repository.CreateAsync(story);
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(UpdateStoryCommand updateStoryCommand)
        {
            var storyToUpdate = await _repository.GetByIdAsync(updateStoryCommand.Id);

            if (storyToUpdate == default)
                throw new ArgumentNullException(nameof(storyToUpdate));

            storyToUpdate.Title = updateStoryCommand.Title;
            storyToUpdate.Message = updateStoryCommand.Message;

            var tagsToUpdateCommand = updateStoryCommand.TagsCommand.Where(t => t.Id != Guid.Empty).ToList();

            foreach (var tag in tagsToUpdateCommand)
            {
                var tagToUpdate = storyToUpdate.Tags.SingleOrDefault(t => t.Id == tag.Id);
                if (tagToUpdate == default)
                    throw new InvalidOperationException("The id is not valid");

                tagToUpdate.Name = tag.Name;
            }

            var tagsToCreate = updateStoryCommand.TagsCommand.Where(t => t.Id == Guid.Empty).Select(t => new Tag
            {
                Name = t.Name
            }).ToList();

            if (tagsToCreate.Any())
                storyToUpdate.Tags.AddRange(tagsToCreate);

            _repository.Update(storyToUpdate);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var storyToDelete = await _repository.GetByIdAsync(id);

            if (storyToDelete == default)
                throw new ArgumentNullException(nameof(storyToDelete));

            _repository.Delete(storyToDelete);
            await _repository.CommitAsync();
        }
    }
}