using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShebaBooksSubscription.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShebaBooksSubscription.Controllers
{
    public class RoleController : Controller
    {
        private ShebaBooksSubscriptionContext sbsc;
        public RoleController(DbContextOptions<ShebaBooksSubscriptionContext> options)
        {
            sbsc = new ShebaBooksSubscriptionContext(options);
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRoles")]
        public JsonResult Get()
        {
            return Json(sbsc.Roles);
        }

        [HttpGet("GetRoleByID")]
        public JsonResult GetRoleByID(int roleId)
        {
            var role = sbsc.Roles.First(r => r.ID == roleId);
            return Json(role);
        }

        [HttpPost("CreateRole")]
        public JsonResult CreateRole([FromBody] Role role)
        {
            var newrole = new Role()
            {
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive
            };
            sbsc.Roles.Add(newrole);
            sbsc.SaveChanges();
            return Json(newrole);
        }

        [HttpPut("UpdateRole")]
        public JsonResult UpdateRole([FromBody] Role newrole)
        {
            var role = sbsc.Roles.First(r=>r.ID == newrole.ID);
            role = newrole;
            sbsc.Update(role);
            sbsc.SaveChanges();
            return Json(role);
        }
    }
}
