using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;

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
            return View("User");//!!!!!!!!!!!!!!!!!!!!!!!!!!! Ichange from "User" to "SQuestion"
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

        [HttpPost]
        public ActionResult UpdateBg(int id, string newbg)//метод для update background в профиле пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();

            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                User u = Sh.Users.Find(id);
                if (u == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    u.backgroundImage = newbg;

                }
            }
            return View(User);
        }

        [HttpPost]
        public ActionResult UpdateMude(int id, string mude)//метод для update статуса в профиле пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();

            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                User u = Sh.Users.Find(id);
                if (u == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    // u.mude = mude;

                }
            }
            return View(User);
        }

        [HttpPost]
        public ActionResult UpdatePersonalInfo(int id, List<string> persinfo)//метод для update персональной информации в профиле пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();

            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                User u = Sh.Users.Find(id);
                if (u == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    u.name = persinfo[0];
                    u.surname = persinfo[1];
                    u.age = Convert.ToInt32(persinfo[2]);
                    u.sex = Convert.ToBoolean(persinfo[3]);
                    u.country = persinfo[4];
                    u.email = persinfo[5];
                    u.password = persinfo[6];
                    u.avatar = persinfo[7];
                    u.isDataOpened = Convert.ToBoolean(persinfo[8]);
                }

            }

            return View(User);
        }


        [HttpPost]
        public ActionResult GetPrivacy(int id)//метод для получения информация  о статусе профиля пользователя(открыт или закрыт для просмотра) made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();
            bool b;
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                User u = Sh.Users.Find(id);
                if (u == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    b = Convert.ToBoolean(u.isDataOpened);
                    if (b == true)
                    {
                        return View(User);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
        }


        [HttpPost]
        public ActionResult DeleteUser(int adminId, int id)//метод для удаления пользователя админом made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();
            if (adminId == -1)
            {

                if (id == null)
                {
                    return HttpNotFound();
                }
                else
                {

                    foreach (Question q in Sh.Questions)
                    {
                        if (q.idReciever == id)
                        {
                            Sh.Questions.Remove(q);
                            Sh.SaveChanges();
                        }
                    }
                    User u = Sh.Users.Find(id);
                    if (u != null)
                    {
                        Sh.Users.Remove(u);
                        Sh.SaveChanges();
                    }
                }

            }
            else
            {
                return HttpNotFound();
            }
            return View(User);

        }
    }
}
