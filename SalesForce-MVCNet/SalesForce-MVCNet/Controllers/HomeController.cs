using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesForce_MVCNet.Models;
using System.Net.Http;
using Salesforce;





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
                // Post Lead to SalesForce
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

                // Save Record to Database
                db.SurveyRecords.Add(surveyRecord);
                await db.SaveChangesAsync();

                // Email Parent after Saving

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mkohlmann_he@dev.bse.edu", "Santa's Little Helper");
                mail.To.Add(new MailAddress(surveyRecord.emailAddress, surveyRecord.parentName));
                mail.Subject = "Thank you for using SantaBot - Attached is your " + surveyRecord.childName + " responses.";
                mail.Body = "Dear " + surveyRecord.parentName + ",\n\nThank you for using StantaBot!\n\nAttached is " + surveyRecord.childName + " responses.\n\nWishList:\n" + surveyRecord.SurveyResponses + "|" + surveyRecord.AcceptedRecommendations + "\n\nHO HO HO! Merry Christmas and Happy New Year!";
                mail.IsBodyHtml = false;

                SmtpClient server = new SmtpClient();
                server.UseDefaultCredentials = false;
                server.Credentials = new System.Net.NetworkCredential("mkohlmann_he@dev.bse.edu", "Fr0$ty01");
                server.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
                server.Host = "smtp.office365.com";
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                server.EnableSsl = true;

                server.Send(mail);




                // Redirect to Thank You page
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