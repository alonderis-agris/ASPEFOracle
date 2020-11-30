using System;
using System.Collections.Generic;

namespace BillingService.Models
{
    public partial class BGateway
    {
        public BGateway()
        {
            BBilling = new HashSet<BBilling>();
        }

        public decimal Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BBilling> BBilling { get; set; }
    }
}
