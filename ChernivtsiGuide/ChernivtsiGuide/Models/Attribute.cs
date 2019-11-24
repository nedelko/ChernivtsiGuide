using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class Attribute
    {
        public int Attribute_code { get; set; }
        public string Attribute_name { get; set; }
        public int Attribute_question { get; set; }
        public int Attribute_rank { get; set; }
        public Question Question { get; set; }
    }
}
