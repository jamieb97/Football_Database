using System;
using System.Collections.Generic;

namespace Football_API.Models
{
    public partial class Owners
    {
        public Owners()
        {
            HeadStaffs = new HashSet<HeadStaffs>();
            Players = new HashSet<Players>();
        }

        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string ClubOwned { get; set; }
        public int? ClubPercOwned { get; set; }
        public int? NetWorthMill { get; set; }

        public virtual ICollection<HeadStaffs> HeadStaffs { get; set; }
        public virtual ICollection<Players> Players { get; set; }
    }
}
