using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class StudentList
    {
        public int EducationOrganisationId { get; set; }
        public int CourseId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
