using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HpTuningInc.Models
{
    public class CarHistory
    {
        [Key]
        public int carHistoryID { get; set; }
        public string Date { get; set; }
        public string Vin { get; set; }
        public string Mile { get; set; }
        public string Source { get; set; }
        public string Comments { get; set; }
    }
}