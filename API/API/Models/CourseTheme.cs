using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CourseTheme
    {
        public int EducationOrganisationId { get; set; }
        public int CourseId { get; set; }
        public int ThemeId { get; set; }
        public int EmployeeId { get; set; }
        public string Theme { get; set; }

        public virtual Course Course { get; set; }
    }
}
