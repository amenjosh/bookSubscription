using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShebaBooksSubscription.Models;
using Microsoft.EntityFrameworkCore;
using ShebaBooksSubscription.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShebaBooksSubscription.Controllers
{
    /// <summary>
    /// Books Controller
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private ShebaBooksSubscriptionContext sbsc;
        public UserController(DbContextOptions<ShebaBooksSubscriptionContext> options)
        {
            sbsc = new ShebaBooksSubscriptionContext(options);
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUsers")]
        public JsonResult Get()
        {
            return Json(sbsc.Users);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetUsersByID")]
        public JsonResult GetUsersByID(int userId)
        {
            var user = sbsc.Users.First(u => u.ID == userId);
            return Json(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [HttpGet("GetUsersByRoleID")]
        public JsonResult GetUserByRoleId(int RoleId)
        {
            var users = sbsc.Users.Select(u => u.RoleID == RoleId);
            return Json(users);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserRoleRelationship")]
        public JsonResult GetUserRoleRelationship()
        {
            var UserRole = sbsc.Users
                            .Include(a => a.Role)
                            .Select(i => new UserRoleViewModel()
                            {
                                RoleID = i.RoleID,
                                RoleName = i.Role.Name,
                                RoleDescription = i.Role.Description,
                                UserID = i.ID,
                                UserName = i.UserName,
                                IsActive = i.IsActive,
                                Password = i.Password
                            }).ToList();


            return Json(UserRole);
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserSubscriptionRelationShip")]
        public JsonResult GetUserSubscriptionRelationships()
        {
            var UserSubscription = sbsc.Subscriptions
                                        .Include(s => s.User)
                                        .Include(p => p.Plan)
                                        .Select(u => new UserSubscriptionViewModel()
                                        {
                                            UserID = u.UserID,
                                            EndDate = u.EndDate,
                                            Password = u.User.Password,
                                            PlanDescription = u.Plan.Description,
                                            PlanName = u.Plan.Name,
                                            StartDate = u.StartDate,
                                            SubscriptionID = u.ID,
                                            SubscriptionIsActive = u.IsActive,
                                            UserIsActive = u.User.IsActive,
                                            UserName = u.User.UserName
                                        }).ToList();
            return Json(UserSubscription);
        }
         
        [HttpPost("CreateUsers")]
        [ProducesResponseType(typeof(User), 200)]
        public JsonResult CreateUser([FromBody] User user)
        { 
            var newuser = new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                RoleID = user.RoleID
            };

            sbsc.Users.Add(newuser);
            sbsc.SaveChanges(); 

            return Json(newuser); 
        }

        [HttpPut("UpdateUsers")]
        [ProducesResponseType(typeof(User), 200)]
        public JsonResult UpdateUser([FromBody] User user)
        {
            var newuser = sbsc.Users.First(u => u.ID == user.ID); 
            newuser = user; 
            sbsc.Users.Update(newuser);
            sbsc.SaveChanges(); 
            return Json(newuser);
        }

    }
}
