using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer Input There Information
        [Authorize(Roles = "Admin, Employee, Customer")]
        public ActionResult CustomerInfo()
        {
            return View();
        }
        // POST: Customer Input There Information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerInfo([Bind(Include = "customerInfoID,FirstName,LastName,Phone,Address,City,State,ZipCode,Email")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Customer"))
                {
                    CustomerInformation customerInformationOne = new CustomerInformation
                    {
                        FirstName = customerInformation.FirstName,
                        LastName = customerInformation.LastName,
                        Phone = customerInformation.Phone,
                        Address = customerInformation.Address,
                        City = customerInformation.City,
                        State = customerInformation.State,
                        ZipCode = customerInformation.ZipCode,
                        Email = User.Identity.Name,
                    };
                    db.CustomerInformation.Add(customerInformationOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (User.IsInRole("Employee"))
                {
                    CustomerInformation customerInformationOne = new CustomerInformation
                    {
                        FirstName = customerInformation.FirstName,
                        LastName = customerInformation.LastName,
                        Phone = customerInformation.Phone,
                        Address = customerInformation.Address,
                        City = customerInformation.City,
                        State = customerInformation.State,
                        ZipCode = customerInformation.ZipCode,
                        Email = customerInformation.Email,
                    };
                    db.CustomerInformation.Add(customerInformationOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(customerInformation);
        }
    }
}