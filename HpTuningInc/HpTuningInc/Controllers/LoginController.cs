using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            if (User.IsInRole("Employee"))
            {
                return RedirectToAction("Index", "Employee");
            }

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
    }
}