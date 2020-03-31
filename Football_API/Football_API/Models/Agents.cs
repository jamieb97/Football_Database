using System;
using System.Collections.Generic;

namespace Football_API.Models
{
    public partial class Agents
    {
        public Agents()
        {
            Players = new HashSet<Players>();
        }

        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int? AgentFeeMill { get; set; }
        public int? PlayerPercOwned { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
