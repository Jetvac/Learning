using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CourseTheme
    {
        public int EducationOrganisationId { get; set; }
        public int CourseId { get; set; }
        public int ThemeId { get; set; }
        public int EmployeeId { get; set; }
        public string Theme { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
    }
}
