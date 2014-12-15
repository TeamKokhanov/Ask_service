using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;
using System.Data;
using System.IO;

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
                ViewBag.login = email;
                ViewBag.password = password;
                User UN = new User
                {
                    email = email,
                    password = password,
                };
                Sh.Users.Add(UN);
                Sh.SaveChanges();
                UN = Sh.Users.Where(u => u.email == email).First();
                Session["id"] = UN.id;
                return AddtoPersonalform();
            }
            else
            {
                if (U.password == password)
                {
                    Session["id"] = U.id;
                    return RunUserWall(U.id);
                }
                else
                {
                    ViewBag.password = "Email or password you entered is incorrect!";
                    return View("../SHome/Index");
                }
            }           
        }

        [HttpPost]
        public ActionResult Register(string name, string surname, string email, string oldpassword, string confirmpassword, string newpassword, string country, string group1,string group2,string mude,string age)
        {
            ViewBag.username = email;
            int id = Convert.ToInt32(Session["id"]);
            User U = Sh.Users.Where(u => u.id ==id).FirstOrDefault();
            if (oldpassword != "")
            {
                if (oldpassword == U.password && oldpassword != "" && newpassword == confirmpassword)
                {
                    U.password = newpassword;
                }
                else
                {
                    ViewBag.pass = "Passwords mismaatch!!!";
                    return View("User");
                }
            }
            if (group1 == "Male")
                U.sex = true;
            else
                U.sex = false;
            if (country != "")
                U.country = country;
            if (age != "")
                U.age = Convert.ToInt32(age);
            if(name!="")
                 U.name = name;
            if(surname!="")
                U.surname = surname;
            if(mude!="")
                U.status = mude;           
            if (group2 == "Open")
                U.isDataOpened = false;
            else U.isDataOpened = true;
            Sh.Entry(U).State = EntityState.Modified;
            Sh.SaveChanges();
            return AddtoPersonalform();            
        }
        [HttpPost]
        public ActionResult LoadAvatar(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/avatar"), fileName);
                file.SaveAs(path);
                User U = Sh.Users.Find(Convert.ToInt32(Session["id"]));
                U.avatar ="/Content/avatar/"+ Convert.ToString(fileName);
                Sh.Entry(U).State = EntityState.Modified;
                Sh.SaveChanges();
            }
            
            // redirect back to the index action to show the form once again
            return AddtoPersonalform();
        }

        [HttpPost]
        public ActionResult LoadBackpicture(HttpPostedFileBase file) 
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/background"), fileName);
                file.SaveAs(path);
                User U = Sh.Users.Find(Convert.ToInt32(Session["id"]));
                U.backgroundImage = "/Content/background/" + Convert.ToString(fileName);
                Sh.Entry(U).State = EntityState.Modified;
                Sh.SaveChanges();
            }

            // redirect back to the index action to show the form once again
            return AddtoPersonalform();
        }


        [HttpPost]
        public ActionResult AddtoPersonalform() 
        {
            User U = Sh.Users.Find(Convert.ToInt32(Session["id"]));
            ViewBag.User = U;
            
            return View("SUser");
        }
        [HttpPost]
        public ActionResult RunUserWall(int id) 
        {
            ViewBag.id = id;
            return View("User");
        }
    }
}
