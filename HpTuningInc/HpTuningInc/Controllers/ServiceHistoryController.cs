using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class ServiceHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Service History Index
        public ActionResult Index(string searchString, string searchStrings)
        {
            if (User.IsInRole("Admin") || (User.IsInRole("Employee")))
            {
                var customerCarInput = from b in db.CustomerCarInput
                                           select b;

                if (!String.IsNullOrEmpty(searchStrings))
                {
                    customerCarInput = customerCarInput.Where(t => t.Email.Contains(searchStrings));
                }

                var carHistory = from a in db.CarHistory
                                 select a;
                TempData["Name"] = searchString;
                if (!String.IsNullOrEmpty(searchString))
                {
                    carHistory = carHistory.Where(s => s.Vin.Contains(searchString) || s.Date.Contains(searchString));

                    return RedirectToAction("ViewHistory");
                }
                return View(customerCarInput.ToList());
            }
            else if (User.IsInRole("Customer"))
            {
                var usersync = User.Identity.Name;
                var syncUser = db.CustomerCarInput.Where(b => b.Email == usersync);
                var carHistory = from a in db.CarHistory
                                 select a;
                TempData["Name"] = searchString;
                if (!String.IsNullOrEmpty(searchString))
                {
                    carHistory = carHistory.Where(s => s.Vin.Contains(searchString) || s.Date.Contains(searchString));

                    return RedirectToAction("ViewHistory");
                }
                return View(syncUser.ToList());
            }
            else
            {
                var carHistory = from a in db.CarHistory
                                 select a;
                TempData["Name"] = searchString;
                if (!String.IsNullOrEmpty(searchString))
                {
                    carHistory = carHistory.Where(s => s.Vin.Contains(searchString) || s.Date.Contains(searchString));

                    return RedirectToAction("ViewHistory");
                }
                return View(db.CustomerCarInput.ToList());
            }
        }

        // View: Be Able To See Car History By Search
        public ActionResult ViewHistory(string searchStrings)
        {
            var searchString = TempData["Name"] as String;
            var carHistory = from a in db.CarHistory
                             select a;

            if (!String.IsNullOrEmpty(searchString + searchStrings))
            {
                carHistory = carHistory.Where(s => s.Vin.Contains(searchString + searchStrings) || s.Date.Contains(searchString + searchStrings));
            }
            return View(carHistory);
        }

        // GET: Enter car service history
        public ActionResult Service()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Service([Bind(Include = "carHistoryID,Date,Vin,Mile,Source,Comments")] CarHistory carHistory)
        {
            if (ModelState.IsValid)
            {
                CarHistory carHistoryOne = new CarHistory
                {
                    Date = carHistory.Date,
                    Vin = carHistory.Vin,
                    Mile = carHistory.Mile,
                    Source = carHistory.Source,
                    Comments = carHistory.Comments,
                };
                db.CarHistory.Add(carHistoryOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carHistory);
        }
    }
}