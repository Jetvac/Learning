using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CompletedCourses = new HashSet<CompletedCourse>();
            EmployeeDisciplines = new HashSet<EmployeeDiscipline>();
            StudyClasses = new HashSet<StudyClass>();
            Courses = new HashSet<Course>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFullname { get; set; } = null!;
        public DateTime EmployeeBirthdate { get; set; }
        public string EmployeePhoneNumber { get; set; } = null!;
        public string EmployeeEmail { get; set; } = null!;
        public int GenderId { get; set; }
        public int PostId { get; set; }
        public int EducationOrganisationId { get; set; }

        public virtual EducationOrganisation EducationOrganisation { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<CompletedCourse> CompletedCourses { get; set; }
        public virtual ICollection<EmployeeDiscipline> EmployeeDisciplines { get; set; }
        public virtual ICollection<StudyClass> StudyClasses { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
