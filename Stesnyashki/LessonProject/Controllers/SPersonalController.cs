using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;
using System.Data;

namespace Stesnyashki.Controllers
{
    public class SPersonalController : Controller
    {
        //
        // GET: /Personal/

        ShyMeContext Sh = new ShyMeContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            List<User> U = Sh.Users.Where(u => u.email == login).ToList();
            if (U.Count == 0)
            {
                User U1 = new User { email = login, password = password };
                Sh.Users.Add(U1);
                Sh.SaveChanges();
                // int idUser = Sh.Users.Find(login).id;
                List<User> TU = Sh.Users.Where(u => u.email == login).ToList();
                foreach (var i in TU)
                {
                    U1 = i;
                }
                int idUser = Convert.ToInt32(U1.id);
                return PersonalReg(idUser);
            }
            else
            {
                foreach (var i in U)
                {
                    if (i.password == password)
                    {
                        //return QuestionList();
                        return View();
                    }
                }               
            }
            return View();
        }

        [HttpPost]
        public ActionResult PersonalReg(int id) 
        {
            List<User> UB = Sh.Users.Where(b => b.id == id).ToList();
            
            foreach (var i in UB) 
            {
                User U = new User { name=i.name,surname=i.surname,age=i.age,sex=i.sex,email=i.email,country=i.country};
                ViewBag.User = U;
            }
            return View("~/View/SPerson/PersonalInfo");
        }

    }
}
