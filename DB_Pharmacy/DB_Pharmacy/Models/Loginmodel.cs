using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DB_Pharmacy.Models
{
    public class Loginmodel
    {
        public int LoginID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string userpasword { get; set; }
        public string role { get; set; }
        public int EID { get; set; }
        public bool Isactive { get; set; }
    }
}