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
    public class SurveyRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SurveyRecords
        public async Task<ActionResult> Index()
        {
            return View(await db.SurveyRecords.ToListAsync());
        }

        // GET: SurveyRecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyRecord surveyRecord = await db.SurveyRecords.FindAsync(id);
            if (surveyRecord == null)
            {
                return HttpNotFound();
            }
            return View(surveyRecord);
        }

        // GET: SurveyRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SurveyRecordID,childName,parentName,emailAddress,childAge,Country,State,City")] SurveyRecord surveyRecord)
        {
            if (ModelState.IsValid)
            {
                db.SurveyRecords.Add(surveyRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(surveyRecord);
        }

        // GET: SurveyRecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyRecord surveyRecord = await db.SurveyRecords.FindAsync(id);
            if (surveyRecord == null)
            {
                return HttpNotFound();
            }
            return View(surveyRecord);
        }

        // POST: SurveyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SurveyRecordID,childName,parentName,emailAddress,childAge,Country,State,City")] SurveyRecord surveyRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(surveyRecord);
        }

        // GET: SurveyRecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyRecord surveyRecord = await db.SurveyRecords.FindAsync(id);
            if (surveyRecord == null)
            {
                return HttpNotFound();
            }
            return View(surveyRecord);
        }

        // POST: SurveyRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SurveyRecord surveyRecord = await db.SurveyRecords.FindAsync(id);
            db.SurveyRecords.Remove(surveyRecord);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
