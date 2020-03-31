using System;
using System.Collections.Generic;

namespace Football_API.Models
{
    public partial class Scouts
    {
        public Scouts()
        {
            HeadStaffs = new HashSet<HeadStaffs>();
        }

        public int ScoutId { get; set; }
        public string ScoutName { get; set; }
        public int? PlayerId { get; set; }
        public string CountryBased { get; set; }

        public virtual Players Player { get; set; }
        public virtual ICollection<HeadStaffs> HeadStaffs { get; set; }
    }
}
