using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CompletedCourse
    {
        public int EmployeeId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public int HoursCount { get; set; }
        public byte[]? Certificate { get; set; }
        public int EducationOrganisationId { get; set; }

        public virtual EducationOrganisation? EducationOrganisation { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
