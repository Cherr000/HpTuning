using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HpTuningInc.Models
{
    public class MaintenanceDetail
    {
        [Key]
        public int maintenanceDetailID { get; set; }
        [Required]
        [Display(Name = "Vin Number")]
        public string Vin { get; set; }
        [Required]
        [Display(Name = "In Date")]
        public string InDate { get; set; }
        [Required]
        [Display(Name = "Out Date")]
        public string OutDate { get; set; }
        [Required]
        [Display(Name = "Maintenance Detail")]
        public string MaintenanceText { get; set; }
    }
}