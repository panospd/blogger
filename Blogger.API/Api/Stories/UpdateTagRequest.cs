using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Api.Stories
{
    public class UpdateTagRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
