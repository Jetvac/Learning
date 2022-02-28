using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ScheduleDiscipline
    {
        public int ScheduleDisciplineId { get; set; }
        public int DisciplineId { get; set; }
        public int ScheduleId { get; set; }
        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; } = null!;
        public virtual Discipline Discipline { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
    }
}
