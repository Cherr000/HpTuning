using HpTuningInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HpTuningInc.Controllers
{
    public class SendMailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReminderPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReminderPage(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                WebMail.Send(reminder.Email
                            , "HPTuningInc - Reminder Service Due",
                            "Hi, This Is Just A Reminder To Let You Know That You Are Due For Service" + "<br />" + "<a href=\"http://localhost:40592/Appointment/Create\">Click Here To Make A Appointment</a>"
                            , null
                            , null
                            , null
                            , true
                            , null
                            , null
                            , null
                            , null
                            , null
                            , reminder.Email);
                return RedirectToAction("SendConfirm");
            }
            return View();
        }

        public ActionResult SendConfirm()
        {
            return View();
        }
    }
}