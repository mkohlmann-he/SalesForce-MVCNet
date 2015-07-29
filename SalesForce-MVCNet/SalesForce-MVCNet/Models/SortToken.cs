using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForce_MVCNet.Models
{
    public class SortToken
    {
        public bool childAge { get; set; }
        public bool Country { get; set; }
        public bool State { get; set; }
        public bool City { get; set; }
        public bool SurveyResults { get; set; }
        public List<int> AgeSelection { get; set; }
        public List<string> CountrySelection { get; set; }
        public List<string> StateSelection { get; set; }
        public List<string> CitySelection { get; set; }
        public List<string> ResultsSelection { get; set; }
    }
}