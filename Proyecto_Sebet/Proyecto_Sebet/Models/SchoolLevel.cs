using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class SchoolLevel
    {
        public SchoolLevel()
        {
            Career = new HashSet<Career>();
            Graduate = new HashSet<Graduate>();
        }

        public int IdSchoolLevel { get; set; }
        public string NameLevel { get; set; }
        public string DescriptionLevel { get; set; }

        public ICollection<Career> Career { get; set; }
        public ICollection<Graduate> Graduate { get; set; }
    }
}
