using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class LegalForm
    {
        public LegalForm()
        {
            Company = new HashSet<Company>();
        }

        public int IdLegalForm { get; set; }
        public string FormName { get; set; }
        public string DescripionL { get; set; }

        public ICollection<Company> Company { get; set; }
    }
}
