using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Educators
    {
        public int IdEducator { get; set; }
        public string Fio { get; set; }
        public string Pasport { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdGroup { get; set; }

        public virtual Groups IdGroupNavigation { get; set; }
    }
}
