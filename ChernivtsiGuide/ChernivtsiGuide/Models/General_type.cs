using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide.Models
{
    public class General_type
    {
        public int General_id { get; set; }
        public string General_name { get; set; }
        public string General_type_logo { get; set; }
        public string General_question { get; set; }
        public Question Question { get; set; }
    }
}
