using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Salesforce.Common;
using Salesforce.Force;
using WebApplication9.Models;


namespace WebApplication9.App_Start
{
    public class SalesForceController : Controller
    {
        // GET: SalesForce
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalesForce Accounts
        public async Task<ActionResult> Accounts()
        {
            var accessToken = Session["AccessToken"].ToString();
            var apiVersion = Session["ApiVersion"].ToString();
            var instanceUrl = Session["InstanceUrl"].ToString();

            var client = new ForceClient(instanceUrl, accessToken, apiVersion);
            var accounts = await client.QueryAsync<AccountViewModel>("SELECT id, name, description FROM Account");

            return View(accounts.Records);
        }

        // GET: SalesForce Leads
        public async Task<ActionResult> Leads()
        {
            var accessToken = Session["AccessToken"].ToString();
            var apiVersion = Session["ApiVersion"].ToString();
            var instanceUrl = Session["InstanceUrl"].ToString();

            var client = new ForceClient(instanceUrl, accessToken, apiVersion);
            var accounts = await client.QueryAsync<LeadsViewModels>("SELECT name, email, country, state, city, description FROM Lead");

            return View(accounts.Records);
        }


        // Send Email
        public ActionResult Email(string Email, string Name)
        {
            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("", "Test Sender");
            //mail.To.Add(new MailAddress(Email, "Test Customer"));
            //mail.Subject = "Thank you for using SantaBot - Attached is your childs responses.";
            //mail.Body = "Dear <Insert Name Here>,\n\nThank you for using StantaBot!\n\nAttached is <Insert Childs Name Here> responses.\n\nWishList:\n";
            //mail.IsBodyHtml = false;

            //SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("", "");
            //client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            //client.Host = "smtp.office365.com";
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.EnableSsl = true;

            //client.Send(mail);

            return Redirect("Leads");
        }
    }
}
