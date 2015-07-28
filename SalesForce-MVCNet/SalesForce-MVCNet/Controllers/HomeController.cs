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
        private SurveyRecord BuildRecord = new SurveyRecord();

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind(Include = "SurveyRecordID,childName")] SurveyRecord surveyRecord)
        {
            if (ModelState.IsValid)
            {
                surveyRecord.AcceptedRecommendations = "";
                surveyRecord.childAge = 0;
                surveyRecord.City = "";
                surveyRecord.Country = "";
                surveyRecord.emailAddress = "";
                surveyRecord.parentName = "";
                surveyRecord.State = "";
                surveyRecord.SurveyResponses = "";

                //db.SurveyRecords.Add(surveyRecord);
                //await db.SaveChangesAsync();
                this.BuildRecord = surveyRecord;
                return RedirectToAction("GetChildAge");
            }

            return View(surveyRecord);
        }


        public async Task<ActionResult> GetChildAge()
        {
            return View(this.BuildRecord);
        }

        // POST: SurveyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetChildAge([Bind(Include = "SurveyRecordID,childAge")] SurveyRecord surveyRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index",new ProductsController());
            }
            return View(surveyRecord);
        }
    }
}