using System;
using System.Collections.Generic;

namespace BillingService.Models
{
    public partial class BUser
    {
        public BUser()
        {
            BBilling = new HashSet<BBilling>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<BBilling> BBilling { get; set; }
    }
}
