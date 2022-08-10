using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserPetPlayDate
    {
        public int UserID { get; set; }

        public int PlayDateID { get; set; }

        public int PetID { get; set; }

        public string PlayDateStatus { get; set; }
    }
}
