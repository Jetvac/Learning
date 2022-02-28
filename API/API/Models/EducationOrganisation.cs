using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class EducationOrganisation
    {
        public EducationOrganisation()
        {
            CompletedCourses = new HashSet<CompletedCourse>();
            Courses = new HashSet<Course>();
            Employees = new HashSet<Employee>();
        }

        public int EducationOrganisationId { get; set; }
        public string EducationOrganisationName { get; set; } = null!;

        public virtual ICollection<CompletedCourse> CompletedCourses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
