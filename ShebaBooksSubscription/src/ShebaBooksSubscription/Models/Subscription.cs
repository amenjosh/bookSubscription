using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaBooksSubscription.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Subscription
    {
        public int ID { get; set; } 

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PlanID { get; set; }
        public Plan Plan { get; set; } 

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
