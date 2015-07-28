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
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required()]
        [Display(Name = "Product Obsolete?")]
        public bool Obsolete { get; set; }

        [Required()]
        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }
    }
}