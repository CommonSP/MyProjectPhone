using System;
using System.Collections.Generic;

namespace Kindergarten
{
    public partial class Schedule
    {
        public int IdSchedule { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Event { get; set; }
        public int IdGroup { get; set; }
        public string Location { get; set; }

        public virtual Groups IdGroupNavigation { get; set; }
    }
}
