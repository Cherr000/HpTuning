using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Look Up Customer Information
        public ActionResult CustomerLookUp(string searchString)
        {
            var customerInformations = from a in db.CustomerInformation
                                       select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                customerInformations = customerInformations.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }
            return View(customerInformations);
        }

        // GET: Look Up Employee Information
        public ActionResult EmployeeLookUp(string searchString)
        {
            var employeeInformation = from a in db.EmployeeInformation
                                       select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeInformation = employeeInformation.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }
            return View(employeeInformation);
        }
    }
}