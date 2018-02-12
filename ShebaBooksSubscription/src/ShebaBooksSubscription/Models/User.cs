using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaBooksSubscription.Models
{
    /// <summary>
    ///  User Model
    /// </summary>
    public class User
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; } 

        public bool IsActive { get; set; }

        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
