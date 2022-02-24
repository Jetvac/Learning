using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class EducationOrganisation
    {
        public EducationOrganisation()
        {
            Courses = new HashSet<Course>();
            Employees = new HashSet<Employee>();
        }

        public int EducationOrganisationId { get; set; }
        public string EducationOrganisationName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
