using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Industry
    {
        public Industry()
        {
            Company = new HashSet<Company>();
        }

        public int IdIndustry { get; set; }
        public string IndustryName { get; set; }
        public string DescriptionI { get; set; }

        public ICollection<Company> Company { get; set; }
    }
}
