using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Entity9
    {
        public int IdParent { get; set; }
        public int IdChild { get; set; }

        public virtual Children IdChildNavigation { get; set; }
        public virtual Parents IdParentNavigation { get; set; }
    }
}
