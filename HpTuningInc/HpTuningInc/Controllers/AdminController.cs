using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // GET: Search Work And Customer Information
        public ActionResult LookUp(string searchString)
        {
            var personInformations = from a in db.Person
                                       select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                personInformations = personInformations.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Role.Contains(searchString));
            }
            return View(personInformations);
        }

        // GET: EmployeeInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person employeeInformation = db.Person.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person employeeInformation = db.Person.Find(id);
            db.Person.Remove(employeeInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}