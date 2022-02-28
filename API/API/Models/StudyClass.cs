using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class StudyClass
    {
        public StudyClass()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int StudyClassId { get; set; }
        public string StudyClassNumber { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
