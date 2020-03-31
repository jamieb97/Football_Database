using System;
using System.Collections.Generic;

namespace Football_API.Models
{
    public partial class HeadStaffs
    {
        public int HeadStaffId { get; set; }
        public string StaffName { get; set; }
        public int? OwnerId { get; set; }
        public string StaffRole { get; set; }
        public int? ScoutId { get; set; }

        public virtual Owners Owner { get; set; }
        public virtual Scouts Scout { get; set; }
    }
}
