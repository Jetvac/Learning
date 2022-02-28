using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Post
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        public int PostId { get; set; }
        public string PostName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
