using System.Collections.Generic;

namespace CCSkype
{
    public class Pipeline
    {
        public string Name { get; set; }

        public IList<string> Users { get; set; }
    }
}