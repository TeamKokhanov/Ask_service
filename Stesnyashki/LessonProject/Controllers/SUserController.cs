using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stesnyashki.Controllers
{
    public class SUserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            ViewBag.username = email;
            ViewBag.pass = password;
            return View("User");
        }

        [HttpPost]
        public ActionResult Register(string name, string email, string password, string confirm)
        {
            ViewBag.username = email;
            if (password == confirm)
                ViewBag.pass = password;
            else
                ViewBag.pass = "Passwords mismaatch!!!";
            return View("User");
        }
    }
}
