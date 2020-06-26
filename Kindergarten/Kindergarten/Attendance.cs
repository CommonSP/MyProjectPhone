using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Attendance
    {
        public Attendance()
        {
            Entity8 = new HashSet<Entity8>();
        }

        public int IdAttendance { get; set; }
        public int IdChild { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Entity8> Entity8 { get; set; }
    }
}
