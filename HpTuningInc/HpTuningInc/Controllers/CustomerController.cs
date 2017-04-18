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

        // GET: Enter Customer Car Information
        public ActionResult CarInfo()
        {
            return View();
        }

        // POST: Enter Customer Car Information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarInfo([Bind(Include = "customerCarInfoID,Email,Vin,Year,Make,Model,Color")] CustomerCarInput customerCarInput)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Employee"))
                {
                    CustomerCarInput customerCarInputOne = new CustomerCarInput
                    {
                        Email = customerCarInput.Email,
                        Vin = customerCarInput.Vin,
                        Year = customerCarInput.Year,
                        Make = customerCarInput.Make,
                        Model = customerCarInput.Model,
                        Color = customerCarInput.Color,
                    };
                    db.CustomerCarInput.Add(customerCarInputOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (User.IsInRole("Customer") || (User.IsInRole("Admin")))
                {
                    CustomerCarInput customerCarInputOne = new CustomerCarInput
                    {
                        Email = User.Identity.Name,
                        Vin = customerCarInput.Vin,
                        Year = customerCarInput.Year,
                        Make = customerCarInput.Make,
                        Model = customerCarInput.Model,
                        Color = customerCarInput.Color,
                    };
                    db.CustomerCarInput.Add(customerCarInputOne);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(customerCarInput);
        }
    }
}