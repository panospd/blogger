using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Core.Services.StoryUseCases
{
    public class UpdateTagCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
