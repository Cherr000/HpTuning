using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HpTuningInc.Models
{
    public class CarInformation
    {
        [Key]
        public int carInformationID { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Vin Number")]
        public string Vin { get; set; }
        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }
        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }
    }
}