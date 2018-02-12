using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShebaBooksSubscription.Models;
using ShebaBooksSubscription.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShebaBooksSubscription.Controllers
{
    public class SubscriptionController : Controller
    {
        private ShebaBooksSubscriptionContext sbsc;
        public SubscriptionController(DbContextOptions<ShebaBooksSubscriptionContext> options)
        {
            sbsc = new ShebaBooksSubscriptionContext(options);
        }

        /// <summary>
        /// Get All Subscription
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSubscription")]
        public JsonResult Get()
        {
            return Json(sbsc.Subscriptions);
        }

        /// <summary>
        /// Get SubsciriptionByID
        /// </summary>
        /// <param name="subsId"></param>
        /// <returns></returns>
        [HttpGet("GetSubsciriptionByID")]
        public JsonResult GetSubscriptionsByID(int subsId)
        {
            var subs = sbsc.Subscriptions.First(s => s.ID == subsId);
            return Json(subs);
        }

        [HttpPost("CreateBookSubscription")]
        public JsonResult SubscribeBook([FromBody] CreateSubscriptionViewModel SubsModel)
        {
            var newsubs = new Subscription()
            {
                EndDate = SubsModel.EndDate,
                IsActive = true,
                PlanID = SubsModel.PlanId,
                StartDate = DateTime.Now,
                UserID = SubsModel.UserId
            };

            sbsc.Subscriptions.Add(newsubs);
            sbsc.SaveChanges();

            return Json(newsubs);
        }
    }
}
