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
        public int IdSchoolLevel { get; set; }
        public int IdArea { get; set; }

        public Area IdAreaNavigation { get; set; }
        public SchoolLevel IdSchoolLevelNavigation { get; set; }
        public ICollection<Graduate> Graduate { get; set; }
    }
}
