using System;
using System.Collections.Generic;

namespace BillingService.Models
{
    public partial class BBilling
    {
        public decimal Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal BUserId { get; set; }
        public decimal Amount { get; set; }
        public decimal BGatewayId { get; set; }
        public string Description { get; set; }

        public virtual BGateway BGateway { get; set; }
        public virtual BUser BUser { get; set; }
    }
}
