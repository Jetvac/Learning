using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ClassRoom
    {
        public ClassRoom()
        {
            ScheduleDisciplines = new HashSet<ScheduleDiscipline>();
        }

        public int ClassRoomId { get; set; }
        public string ClassRoomNumber { get; set; } = null!;

        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
