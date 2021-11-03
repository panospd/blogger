using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Core
{
    public class Story
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
