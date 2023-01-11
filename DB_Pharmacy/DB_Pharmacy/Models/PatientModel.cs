using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DB_Pharmacy.Models
{
    public class PatientModel
    {
        [Required]
        public int PID { get; set; }

        [Required]
        public string PName { get; set; }

       
        public string Paddress { get; set; }

        [Required]
        public string Diease { get; set; }
    }
}