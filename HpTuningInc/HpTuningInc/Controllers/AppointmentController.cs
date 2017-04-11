using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appointment
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index(string searchString)
        {
            var events = from a in db.Events
                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.Email.Contains(searchString) || s.Title.Contains(searchString));
            }
            return View(events);
        }

        public JsonResult GetEvents()
        {
            //Here MyDatabaseEntities is our entity datacontext (see Step 4)
            using (EntitiesOne dc = new EntitiesOne())
            {
                var v = dc.Events.OrderBy(a => a.StartAt).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Title,Description,StartAt,EndAt,IsFullDay,Email")] Events events)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Customer"))
                {
                    Events eventsOne = new Events
                    {
                        Title = events.Title,
                        Description = events.Description,
                        StartAt = events.StartAt,
                        EndAt = events.EndAt,
                        IsFullDay = events.IsFullDay,
                        Email = User.Identity.Name,
                    };
                    db.Events.Add(eventsOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Events eventsOne = new Events
                    {
                        Title = events.Title,
                        Description = events.Description,
                        StartAt = events.StartAt,
                        EndAt = events.EndAt,
                        IsFullDay = events.IsFullDay,
                        Email = events.Email,
                    };
                    db.Events.Add(eventsOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(events);
        }
    }
}