using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class WeekDay
    {
        public WeekDay()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int WeekDayId { get; set; }
        public string WeekDayName { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
