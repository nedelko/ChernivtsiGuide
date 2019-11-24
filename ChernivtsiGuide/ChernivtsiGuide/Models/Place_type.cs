using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class Place_type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type_logo { get; set; }
        public int General_type { get; set; }
        public General_type general_t { get; set; }
    }
}
