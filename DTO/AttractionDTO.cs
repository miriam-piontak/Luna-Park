using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AttractionDTO
    {
        public int AttractionId { get; set; }
        public string AttractionName { get; set; } = null!;
        public int MaxCapacity { get; set; }

    }
}
