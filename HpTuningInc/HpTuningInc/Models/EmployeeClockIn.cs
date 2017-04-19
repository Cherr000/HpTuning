using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HpTuningInc.Models
{
    public class EmployeeClockIn
    {
        [Key]
        public int ClockID { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }
        public string Hour { get; set; }
    }
}