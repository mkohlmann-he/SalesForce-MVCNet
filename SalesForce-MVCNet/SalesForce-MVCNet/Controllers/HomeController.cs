using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesForce_MVCNet.Models;

namespace SalesForce_MVCNet.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind(Include = "SurveyRecordID,childName,parentName,emailAddress,childAge,Country,State,City,SurveyResponses,AcceptedRecommendations")] SurveyRecord surveyRecord)
        {
            if (ModelState.IsValid)
            {
                db.SurveyRecords.Add(surveyRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }

            return View(surveyRecord);
        }

        public ActionResult ThankYou()
        {

            return View();
        }


    }
}