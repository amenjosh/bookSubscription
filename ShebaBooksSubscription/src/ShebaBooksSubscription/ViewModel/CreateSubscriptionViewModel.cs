using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaBooksSubscription.ViewModel
{
    public class CreateSubscriptionViewModel
    {
        public int UserId { get; set; }

        public int PlanId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; } 

    }
}
