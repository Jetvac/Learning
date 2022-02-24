using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CompletedCourses = new HashSet<CompletedCourse>();
            EmployeeDisciplines = new HashSet<EmployeeDiscipline>();
            StudentLists = new HashSet<StudentList>();
            StudyClasses = new HashSet<StudyClass>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFullname { get; set; }
        public DateTime EmployeeBirthdate { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public int GenderId { get; set; }
        public int PostId { get; set; }
        public int EducationOrganisationId { get; set; }

        public virtual EducationOrganisation EducationOrganisation { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CompletedCourse> CompletedCourses { get; set; }
        public virtual ICollection<EmployeeDiscipline> EmployeeDisciplines { get; set; }
        public virtual ICollection<StudentList> StudentLists { get; set; }
        public virtual ICollection<StudyClass> StudyClasses { get; set; }
    }
}
