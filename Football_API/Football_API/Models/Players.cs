using System;
using System.Collections.Generic;

namespace Football_API.Models
{
    public partial class Players
    {
        public Players()
        {
            Scouts = new HashSet<Scouts>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int? PlayerAge { get; set; }
        public int? OwnerId { get; set; }
        public int? AgentId { get; set; }
        public int? Salary { get; set; }
        public int? ContractLength { get; set; }

        public virtual Agents Agent { get; set; }
        public virtual Owners Owner { get; set; }
        public virtual ICollection<Scouts> Scouts { get; set; }
    }
}
