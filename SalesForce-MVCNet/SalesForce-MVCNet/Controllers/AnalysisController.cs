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
    public class AnalysisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SortToken sortToken = new SortToken();
        private System.Linq.IQueryable<SalesForce_MVCNet.Models.SurveyRecord> records;

        public AnalysisController()
        {
            ReloadRecords();
        }

        // Refresh Data from Database
        public void ReloadRecords()
        {
            this.records = from rec in db.SurveyRecords
                           select rec;
        }

        // GET: Analysis
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [Authorize]
        // GET: Filter
        public ActionResult Filter(string sortOrder)
        {
            // Preset Ascendings/Decendings on first open
            if (String.IsNullOrEmpty(sortOrder))
            {
                ViewBag.AgeSortParm = "childAge_asc";
                ViewBag.CountrySortParam = "country_asc";
                ViewBag.StateSortParam = "state_asc";
                ViewBag.CitySortParam = "city_asc";
                ViewBag.ResponseSortParam = "response_asc";
            }
                        
            // Otherwise Update existing sort orders
            ViewBag.AgeSortParm = sortOrder == "childAge_asc" ? "childAge_desc" : ViewBag.AgeSortParm;
            ViewBag.AgeSortParm = sortOrder == "childAge_desc" ? "childAge_asc" : ViewBag.AgeSortParm;
            ViewBag.CountrySortParam = sortOrder == "country_asc" ? "country_desc" : ViewBag.CountrySortParam;
            ViewBag.CountrySortParam = sortOrder == "country_desc" ? "country_asc" : ViewBag.CountrySortParam;
            ViewBag.StateSortParam = sortOrder == "state_asc" ? "state_desc" : ViewBag.StateSortParam;
            ViewBag.StateSortParam = sortOrder == "state_desc" ? "state_asc" : ViewBag.StateSortParam;
            ViewBag.CitySortParam = sortOrder == "city_asc" ? "city_desc" : ViewBag.CitySortParam;
            ViewBag.CitySortParam = sortOrder == "city_desc" ? "city_asc" : ViewBag.CitySortParam;
            ViewBag.ResponseSortParam = sortOrder == "response_asc" ? "response_desc" : ViewBag.ResponseSortParam;
            ViewBag.ResponseSortParam = sortOrder == "response_desc" ? "response_asc" : ViewBag.ResponseSortParam;

            //var records = from rec in db.SurveyRecords
            //                select rec;
            
            switch (sortOrder)
            {
                case "childAge_desc":
                    records = records.OrderBy(rec => rec.childAge);
                    break;
                case "childAge_asc":
                    records = records.OrderByDescending(rec => rec.childAge);
                    break;
                case "country_desc":
                    records = records.OrderBy(rec => rec.Country);
                    break;
                case "country_asc":
                    records = records.OrderByDescending(rec => rec.Country);
                    break;
                case "state_desc":
                    records = records.OrderBy(rec => rec.State);
                    break;
                case "state_asc":
                    records = records.OrderByDescending(rec => rec.State);
                    break;
                case "city_desc":
                    records = records.OrderBy(rec => rec.City);
                    break;
                case "city_asc":
                    records = records.OrderByDescending(rec => rec.City);
                    break;
                case "response_desc":
                    records = records.OrderBy(rec => rec.SurveyResponses);
                    break;
                case "response_asc":
                    records = records.OrderByDescending(rec => rec.SurveyResponses);
                    break;

                default:
                    records = records.OrderBy(rec => rec.childAge);
                    break;
            }

            // Populate List Select Boxes

            // Note: I KNOW there HAS to be a better way of doing this... 
            // This is a ridiculous O(n^2) process, but I can't figure out a better way. 
            // It seems like there should be an easy way to build a list box without having to iterate the entire loop each time.

            List<int> ListBoxChildAge = new List<int>();
            List<string> ListBoxCountry = new List<string>();
            List<string> ListBoxState = new List<string>();
            List<string> ListBoxCity = new List<string>();
            List<string> ListBoxResults = new List<string>();

            //foreach (System.Linq.IQueryable<SalesForce_MVCNet.Models.SurveyRecord> SurveyRecord in records)
            foreach (SurveyRecord surveyRecord in records)
            {
                if (!ListBoxChildAge.Contains(surveyRecord.childAge))
                {
                    ListBoxChildAge.Add(surveyRecord.childAge);
                }
                if (!ListBoxCountry.Contains(surveyRecord.Country))
                {
                    ListBoxCountry.Add(surveyRecord.Country);
                }
                if (!ListBoxState.Contains(surveyRecord.State))
                {
                    ListBoxState.Add(surveyRecord.State);
                }
                if (!ListBoxCity.Contains(surveyRecord.City))
                {
                    ListBoxCity.Add(surveyRecord.City);
                }
                if (!ListBoxResults.Contains(surveyRecord.SurveyResponses))
                {
                    ListBoxResults.Add(surveyRecord.SurveyResponses);
                }
            }

            SelectList SelListChildAge = new SelectList(ListBoxChildAge);
            SelectList SelListBoxCountry = new SelectList(ListBoxCountry);
            SelectList SelListState = new SelectList(ListBoxState);
            SelectList SelListCity = new SelectList(ListBoxCity);
            SelectList SelListResults = new SelectList(ListBoxResults);
            ViewBag.ListBoxChildAge = SelListChildAge;
            ViewBag.ListBoxCountry = SelListBoxCountry;
            ViewBag.ListBoxState = SelListState;
            ViewBag.ListBoxCity = SelListCity;
            ViewBag.ListBoxResults = SelListResults;

            return View(records);
        }
    }
}