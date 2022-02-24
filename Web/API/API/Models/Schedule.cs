using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleDisciplines = new HashSet<ScheduleDiscipline>();
        }

        public int StudyClassId { get; set; }
        public int WeekDayId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int ScheduleId { get; set; }

        public virtual StudyClass StudyClass { get; set; }
        public virtual WeekDay WeekDay { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
