﻿using System;
using System.Collections.Generic;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public class UpdateStoryCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public List<UpdateTagCommand> TagsCommand { get; set; }
    }
}
