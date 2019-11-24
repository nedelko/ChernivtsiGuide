using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class Place_attribute
    {
        public int Attribute_code { get; set; }
        public int Place_code { get; set; }
        public Attribute Attribute { get; set; }
        public Place Place { get; set; }
    }
}
