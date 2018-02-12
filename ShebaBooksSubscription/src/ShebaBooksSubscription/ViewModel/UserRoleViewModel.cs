using ShebaBooksSubscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaBooksSubscription.ViewModel
{
    public class UserRoleViewModel
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
