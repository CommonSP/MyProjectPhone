using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Children
    {
        public Children()
        {
            Entity8 = new HashSet<Entity8>();
            Entity9 = new HashSet<Entity9>();
        }

        public int IdChild { get; set; }
        public string Fio { get; set; }
        public string BirdthSerteficate { get; set; }
        public int IdGroup { get; set; }

        public virtual Groups IdGroupNavigation { get; set; }
        public virtual ICollection<Entity8> Entity8 { get; set; }
        public virtual ICollection<Entity9> Entity9 { get; set; }
    }
}
