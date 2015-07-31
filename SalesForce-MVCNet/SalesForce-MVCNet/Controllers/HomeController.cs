using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesForce_MVCNet.Models;
using System.Net.Http;





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
                using (WebClient client = new WebClient())
                {
                    byte[] response =
                    client.UploadValues("https://www.salesforce.com/servlet/servlet.WebToLead?encoding=UTF-8", new NameValueCollection()
                    {
                        { "oid", "00D37000000L4sB"},
                        { "retURL", "http://google.com"},
                        { "first_name", surveyRecord.childName },
                        { "email", surveyRecord.emailAddress },
                        { "city", surveyRecord.City },
                        { "state", surveyRecord.State },
                        { "country", surveyRecord.Country },
                        { "description", surveyRecord.SurveyResponses }

                    });
                    // string result = System.Text.Encoding.UTF8.GetString(response);
                }

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

        public ActionResult SumbitTest()
        {

            return View();
        }



        public ActionResult SalesForceRecordPullTest()
        {
            return View();
 
        }


    }
}