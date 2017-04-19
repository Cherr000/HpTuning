using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        // GET: Employee TIME CLOCK IN OR OUT
        public ActionResult TimeClock()
        {
            return View(db.EmployeeClockIn.ToList());
        }

        // GET: EMPLOYEE CLOCK IN
        public ActionResult ClockIn([Bind(Include = "Email,Date,ClockIn,ClockOut,Hour")] EmployeeClockIn employeeClockIn)
        {
            if (ModelState.IsValid)
            {
                employeeClockIn.ClockIn = DateTime.Now.ToString("HH:mm");
                employeeClockIn.Date = DateTime.Now.ToShortDateString();
                EmployeeClockIn employeeClockInOne = new EmployeeClockIn
                {
                    Email = User.Identity.Name,
                    Date = employeeClockIn.Date,
                    ClockIn = employeeClockIn.ClockIn,
                };
                db.EmployeeClockIn.Add(employeeClockInOne);
                db.SaveChanges();
                return RedirectToAction("TimeClock");
            }

            return View(employeeClockIn);
        }

        // GET: EMPLOYEE CLOCK OUT
        public ActionResult ClockOut([Bind(Include = "Email,Date,ClockIn,ClockOut,Hour")] EmployeeClockIn employeeClockIn)
        {
            if (ModelState.IsValid)
            {
                employeeClockIn.ClockOut = DateTime.Now.ToString("HH:mm");
                employeeClockIn.Date = DateTime.Now.ToShortDateString();
                EmployeeClockIn employeeClockInOne = new EmployeeClockIn
                {
                    Email = User.Identity.Name,
                    Date = employeeClockIn.Date,
                    ClockOut = employeeClockIn.ClockOut,
                };
                db.EmployeeClockIn.Add(employeeClockInOne);
                db.SaveChanges();
                return RedirectToAction("TimeClock");
            }

            return View(employeeClockIn);
        }
    }
}