using System;

namespace Blogger.API.Core
{
    public class Tag 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Story Story { get; set; }
    }
}
