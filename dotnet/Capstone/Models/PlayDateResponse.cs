using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PlayDateResponse
    {
        public int PlayDateID { get; set; }
        public int CreatorID { get; set; }
        public string PlayParkAddress { get; set; }

        public string PlayParkName { get; set; }

        public string PlayParkLocationNotes { get; set; }

        public DateTime PlayDateTimeDate { get; set; }

        public string PetName { get; set; }
    }
}
