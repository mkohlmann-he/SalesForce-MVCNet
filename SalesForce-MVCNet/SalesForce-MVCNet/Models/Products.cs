using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesForce_MVCNet.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public string Description { get; set; }

        [Required()]
        public bool Obsolete { get; set; }

        [Required()]
        public int QuantityInStock { get; set; }
    }
}