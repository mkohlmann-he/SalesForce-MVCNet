using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesForce_MVCNet.Models
{
    public class SurveyRecord
    {
        [Key]
        public int SurveyRecordID { get; set; }

        [Required()]
        [Display(Name = "Child's Name")]
        public string childName { get; set; }

        [Display(Name = "Parent's Name")]
        public string parentName { get; set; }

        [Display(Name="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }
        
        [Display(Name = "Child's Age")]
        public int childAge { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Survey's Responses")]
        public string SurveyResponses { get; set; }

        [Display(Name = "Recommendations that were Accepted")]
        public string AcceptedRecommendations { get; set; }

    }
}