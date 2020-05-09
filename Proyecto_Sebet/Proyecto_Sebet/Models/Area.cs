using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Area
    {
        public Area()
        {
            Career = new HashSet<Career>();
            Graduate = new HashSet<Graduate>();
        }

        public int IdArea { get; set; }
        public string NameArea { get; set; }
        public string DescriptionArea { get; set; }

        public ICollection<Career> Career { get; set; }
        public ICollection<Graduate> Graduate { get; set; }
    }
}
