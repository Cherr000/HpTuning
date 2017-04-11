using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee Input There Information
        public ActionResult InputInfo()
        {
            return View();
        }
        // POST: Employee Input There Information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InputInfo([Bind(Include = "EmployeeInfoID,FirstName,LastName,Phone,Address,City,State,ZipCode,Email")] EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                EmployeeInformation employeeInformationOne = new EmployeeInformation
                {
                    FirstName = employeeInformation.FirstName,
                    LastName = employeeInformation.LastName,
                    Phone = employeeInformation.Phone,
                    Address = employeeInformation.Address,
                    City = employeeInformation.City,
                    State = employeeInformation.State,
                    ZipCode = employeeInformation.ZipCode,
                    Email = User.Identity.Name,
                };
                db.EmployeeInformation.Add(employeeInformationOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeInformation);
        }
    }
}