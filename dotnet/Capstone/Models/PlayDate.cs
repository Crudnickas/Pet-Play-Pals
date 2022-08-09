using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PlayDate
    {
        public string Location { get; set; }

        public int ScheduleID { get; set; }

        public string PlayDateName { get; set; }

        public string PlayDateAddress { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
