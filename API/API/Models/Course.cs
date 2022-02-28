using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseThemes = new HashSet<CourseTheme>();
            Employees = new HashSet<Employee>();
        }

        public int EducationOrganisationId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

        public virtual EducationOrganisation EducationOrganisation { get; set; } = null!;
        public virtual ICollection<CourseTheme> CourseThemes { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
