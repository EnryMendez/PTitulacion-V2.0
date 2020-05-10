using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Answer
    {
        public Answer()
        {
            TestReview = new HashSet<TestReview>();
        }

        public int IdAnswer { get; set; }
        public int IdQuestion { get; set; }
        public string AnswerQ { get; set; }
        public int? IdGraduate { get; set; }

        public Graduate IdGraduateNavigation { get; set; }
        public ICollection<TestReview> TestReview { get; set; }
    }
}
