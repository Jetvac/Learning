using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            EmployeeDisciplines = new HashSet<EmployeeDiscipline>();
            ScheduleDisciplines = new HashSet<ScheduleDiscipline>();
        }

        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int? WeeklyLoad { get; set; }

        public virtual ICollection<EmployeeDiscipline> EmployeeDisciplines { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
