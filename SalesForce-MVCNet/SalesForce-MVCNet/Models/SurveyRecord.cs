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
        public string childName { get; set; }

        [Required()]
        public string parentName { get; set; }

        [Required()]
        [Display(Name="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }
        
        [Required()]
        public int childAge { get; set; }

        [Required()]
        public string Country { get; set; }

        [Required()]
        public string State { get; set; }

        [Required()]
        public string City { get; set; }

        public string SurveyResponses { get; set; }

        public string AcceptedRecommendations { get; set; }

    }
}