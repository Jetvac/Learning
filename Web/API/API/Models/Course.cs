using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseThemes = new HashSet<CourseTheme>();
            StudentLists = new HashSet<StudentList>();
        }

        public int EducationOrganisationId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

        public virtual EducationOrganisation EducationOrganisation { get; set; }
        public virtual ICollection<CourseTheme> CourseThemes { get; set; }
        public virtual ICollection<StudentList> StudentLists { get; set; }
    }
}
