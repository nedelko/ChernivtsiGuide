using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class Photo
    {
        public int Image_id { get; set; }
        public string Image_url { get; set; }
        public int Place_code { get; set; }
        public Place Place { get; set; }
    }
}
