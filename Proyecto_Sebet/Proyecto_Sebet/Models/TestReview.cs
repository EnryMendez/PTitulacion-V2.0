using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class TestReview
    {
        public int IdQualification { get; set; }
        public int? IdQuestion { get; set; }
        public int? IdAnswer { get; set; }
        public bool? AnswerState { get; set; }
        public int? Score { get; set; }

        public Answer IdAnswerNavigation { get; set; }
        public Question IdQuestionNavigation { get; set; }
    }
}
