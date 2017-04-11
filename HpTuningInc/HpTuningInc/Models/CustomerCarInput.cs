using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HpTuningInc.Models
{
    public class CustomerCarInput
    {
        [Key]
        public int customerCarInfoID { get; set; }
        public string Email { get; set; }
        public string Vin { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}