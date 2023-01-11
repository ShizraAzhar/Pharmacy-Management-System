using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DB_Pharmacy.Models
{
    public class Employeemodel
    {
       [Required]
        public int EID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string eaddress { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Contactno { get; set; }

        [Required]
        public string Nationality { get; set; }
        public string Age { get; set; }

        public string Imagepath { get; set; }

        public Loginmodel logininfo { get; set; }
    }
}