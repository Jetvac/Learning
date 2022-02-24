using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
