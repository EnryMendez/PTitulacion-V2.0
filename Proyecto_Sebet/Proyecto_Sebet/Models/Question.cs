using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Question
    {
        public Question()
        {
            TestReview = new HashSet<TestReview>();
        }

        public int IdQuestion { get; set; }
        public int IdTest { get; set; }
        public string QuestionDescription { get; set; }

        public Test IdTestNavigation { get; set; }
        public ICollection<TestReview> TestReview { get; set; }
    }
}
