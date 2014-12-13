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
        ShyMeContext Sh = new ShyMeContext();
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            User U = Sh.Users.Where(u => u.email == email).FirstOrDefault();
            if (U == null) 
            {
                return View("SUser");
            }
            if (U.email != null)
            {
                if (U.password == password)
                {
                    Session["id"] = U.id;
                    return View("User");
                }
                else
                {
                    ViewBag.password = "Email or password you entered is incorrect!";
                    return View("../SHome/Index");
                }
            }
            else
            {              
                return View("SUser");               
            }
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
            

                User u = Sh.Users.Find(id);
               u.backgroundImage = newbg;
            return View("User");
        }

        [HttpPost]
        public ActionResult UpdateMude(int id, string mude)//метод для update статуса в профиле пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();


                User u = Sh.Users.Find(id);
                // u.mude = mude;

             
            
            return View("User");
        }

        [HttpPost]
        public ActionResult UpdatePersonalInfo(int id, List<string> persinfo)//метод для update персональной информации в профиле пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();


       
                User u = Sh.Users.Find(id);
              
                    u.name = persinfo[0];
                    u.surname = persinfo[1];
                    u.age = Convert.ToInt32(persinfo[2]);
                    u.sex = Convert.ToBoolean(persinfo[3]);
                    u.country = persinfo[4];
                    u.email = persinfo[5];
                    u.password = persinfo[6];
                    u.avatar = persinfo[7];
                    u.isDataOpened = Convert.ToBoolean(persinfo[8]);
                

            

            return View("User");
        }


        [HttpPost]
        public ActionResult GetPrivacy(int id)//метод для получения информация  о статусе профиля пользователя(открыт или закрыт для просмотра) made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();
            bool b;
  
                User u = Sh.Users.Find(id);
             
                
                    b = Convert.ToBoolean(u.isDataOpened);
                    if (b == true)
                    {
                        return View("User");
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                
            
        }

        [HttpPost]
        public string SetAvatarname(int id) //получаем директиву аватара,чтобы показать ее в профайле
        {
            ShyMeContext Sh = new ShyMeContext();
            string s = "../Content/icon/avatar.png";
            if (s == null)
            {
                return "Enter photo directory";
            }
            else
            {
                User u = Sh.Users.Find(id);
                s = u.avatar;
            }
            return s;
        }
        
    }
}
