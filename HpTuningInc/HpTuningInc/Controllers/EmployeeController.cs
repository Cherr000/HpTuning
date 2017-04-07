using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Informations/Create
        public ActionResult Information()
        {
            return View();
        }

        // POST: Informations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Information([Bind(Include = "informationID,Role,FirstName,LastName,Phone,Address,City,State,ZipCode,Email")] Person person)
        {
            if (ModelState.IsValid)
            {
                Person personOne = new Person
                {
                    Role = person.Role,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Phone = person.Phone,
                    Address = person.Address,
                    City = person.City,
                    State = person.State,
                    ZipCode = person.ZipCode,
                    Email = User.Identity.Name,
                };
                db.Person.Add(personOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: CarInformations/Create
        public ActionResult Cars()
        {
            return View();
        }

        // POST: CarInformations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cars([Bind(Include = "Vin,Make,Model,Color")] CarInformation carInformation)
        {
            if (ModelState.IsValid)
            {
                CarInformation carInformationOne = new CarInformation
                {
                    Vin = carInformation.Vin,
                    Make = carInformation.Make,
                    Model = carInformation.Model,
                    Color = carInformation.Color,
                };
                db.CarInformation.Add(carInformationOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carInformation);
        }
    }
}