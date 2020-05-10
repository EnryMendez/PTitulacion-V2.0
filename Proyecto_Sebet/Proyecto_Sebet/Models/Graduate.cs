using System;
using System.Collections.Generic;

namespace Proyecto_Sebet.Models
{
    public partial class Graduate
    {
        public Graduate()
        {
            Answer = new HashSet<Answer>();
        }

        public int IdGraduate { get; set; }
        public int Inscription { get; set; }
        public string GraduateName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordG { get; set; }
        public int IdCareer { get; set; }

        public Career IdCareerNavigation { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
