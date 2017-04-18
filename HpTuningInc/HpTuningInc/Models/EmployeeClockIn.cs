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
        public string Email { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime Break { get; set; }
        public DateTime ClockOut { get; set; }
        public string Hour { get; set; }
    }
}