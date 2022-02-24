using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Post
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        public int PostId { get; set; }
        public string PostName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
