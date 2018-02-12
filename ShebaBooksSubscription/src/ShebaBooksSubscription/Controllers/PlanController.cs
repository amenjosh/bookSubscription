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
    /// <summary>
    /// 
    /// </summary>
    public class PlanController : Controller
    {
        private ShebaBooksSubscriptionContext sbsc;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public PlanController(DbContextOptions<ShebaBooksSubscriptionContext> options)
        {
            sbsc = new ShebaBooksSubscriptionContext(options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPlans")]
        public JsonResult Get()
        {
            return Json(sbsc.Plans);
        }

        [HttpGet("GetPlanByID")]
        public JsonResult GetByID(int PlanId)
        {
            return Json(sbsc.Plans.First(p => p.ID == PlanId));
        }

        [HttpPost("CreateNewPlan")]
        public JsonResult CreatePlan([FromBody] Plan plan)
        {
            var newplan = new Plan()
            {
                Name = plan.Name,
                Description = plan.Description
            }; 
            sbsc.Plans.Add(newplan);
            sbsc.SaveChanges();

            return Json(newplan);
        }

        [HttpPut("UpdatePlan")]
        public JsonResult UpdatePlan([FromBody] Plan newplan)
        {
            var plan = sbsc.Plans.First(p=>p.ID == newplan.ID);
            plan = newplan;
            sbsc.Plans.Update(plan);
            sbsc.SaveChanges();
            return Json(plan);
        }
    }
}
