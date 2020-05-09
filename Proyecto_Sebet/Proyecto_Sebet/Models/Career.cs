using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Career
    {
        public Career()
        {
            Graduate = new HashSet<Graduate>();
        }

        public int IdCareer { get; set; }
        public string NameCareer { get; set; }
        public string DescriptionCareer { get; set; }

        public ICollection<Graduate> Graduate { get; set; }
    }
}
