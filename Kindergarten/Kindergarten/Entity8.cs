using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Entity8
    {
        public int IdAttendance { get; set; }
        public int IdChild { get; set; }

        public virtual Attendance IdAttendanceNavigation { get; set; }
        public virtual Children IdChildNavigation { get; set; }
    }
}
