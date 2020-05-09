using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Company
    {
        public Company()
        {
            Job = new HashSet<Job>();
            Test = new HashSet<Test>();
        }

        public int IdCompany { get; set; }
        public string RecluiterName { get; set; }
        public string LastName { get; set; }
        public string Rfc { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string PasswordR { get; set; }
        public int IdIndustry { get; set; }
        public int IdLegalForm { get; set; }

        public Industry IdIndustryNavigation { get; set; }
        public LegalForm IdLegalFormNavigation { get; set; }
        public ICollection<Job> Job { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
