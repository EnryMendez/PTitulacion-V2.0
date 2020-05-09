using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Job
    {
        public int IdJob { get; set; }
        public string Employment { get; set; }
        public int Vacants { get; set; }
        public decimal Salary { get; set; }
        public int IdCompany { get; set; }

        public Company IdCompanyNavigation { get; set; }
    }
}
