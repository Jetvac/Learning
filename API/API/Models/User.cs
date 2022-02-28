using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class User
    {
        public int EmployeeId { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
