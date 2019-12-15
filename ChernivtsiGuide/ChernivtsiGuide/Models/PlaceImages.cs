using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class PlaceImages
    {
        public int Place_code { get; set; }
        public string Place_name { get; set; }
        public int Place_type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Open_time { get; set; }
        public string Close_time { get; set; }
        public List<string> images { get; set; }
    }
}
