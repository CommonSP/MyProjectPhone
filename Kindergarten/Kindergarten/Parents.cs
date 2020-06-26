using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Parents
    {
        public Parents()
        {
            Entity9 = new HashSet<Entity9>();
        }

        public int IdParent { get; set; }
        public string Fio { get; set; }
        public string Pasport { get; set; }
        public int IdChild { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Entity9> Entity9 { get; set; }
    }
}
