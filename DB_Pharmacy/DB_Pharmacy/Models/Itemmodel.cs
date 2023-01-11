using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DB_Pharmacy.Models
{
    public class Itemmodel
    {
        [Required]
        public int ItemID { get; set; }

        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemBrandName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public string Unitprice { get; set; }

        [Required]
        public string Sellprice { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Expiredate { get; set; }

       
    }
}