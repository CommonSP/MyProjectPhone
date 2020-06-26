using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Groups
    {
        public Groups()
        {
            Children = new HashSet<Children>();
            Educators = new HashSet<Educators>();
            Schedule = new HashSet<Schedule>();
        }

        public int IdGroup { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Children> Children { get; set; }
        public virtual ICollection<Educators> Educators { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
