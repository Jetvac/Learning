using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class EmployeeDiscipline
    {
        public int EmployeeDisciplineId { get; set; }
        public int? EmployeeId { get; set; }
        public int? DisciplineId { get; set; }

        public virtual Discipline? Discipline { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
