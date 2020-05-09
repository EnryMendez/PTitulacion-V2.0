using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Test
    {
        public Test()
        {
            Question = new HashSet<Question>();
        }

        public int IdTest { get; set; }
        public int IdCompany { get; set; }
        public string TestName { get; set; }
        public int TotalQuestions { get; set; }

        public Company IdCompanyNavigation { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
