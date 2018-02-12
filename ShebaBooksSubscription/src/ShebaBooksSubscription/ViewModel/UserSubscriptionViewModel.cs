using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaBooksSubscription.ViewModel
{
    public class UserSubscriptionViewModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool UserIsActive { get; set; }

        public int SubscriptionID { get; set; }

        public bool SubscriptionIsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PlanName { get; set; }

        public string PlanDescription { get; set; }
    }
}
