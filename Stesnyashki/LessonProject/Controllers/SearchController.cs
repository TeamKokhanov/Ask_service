using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;

namespace Stesnyashki.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        ShyMeContext Sh = new ShyMeContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string name, string surname, string age, string sex, string country)
        {           
            List<User> U = new List<User>();
            List<User> U1 = new List<User>();
            List<User> U2 = new List<User>();
            List<User> U3 = new List<User>();
            List<User> U4 = new List<User>();
            List<User> U5 = new List<User>();
            int a1 = 0, b1 = 0, c1 = 0, d1 = 0, e1 = 0;
            if (name != "")//заполняем начальный список
            {
                U = Sh.Users.Where(b => b.name == name).ToList();
            }
            else
            {
                if (surname != "")
                {
                    U = Sh.Users.Where(b => b.surname == surname).ToList();
                }
                else
                {
                    if (age != "")
                    {
                        int age1 = Convert.ToInt32(age);
                        U = Sh.Users.Where(b => b.age == age1).ToList();
                    }
                    else
                    {
                        if (sex != "")
                        {
                            bool s = true;
                            if (sex == "Male")
                                s = true;
                            else
                                s = false;
                            U = Sh.Users.Where(b => b.sex == s).ToList();
                        }
                        else
                        {
                            if (country != "")
                            {
                                U = Sh.Users.Where(b => b.country == country).ToList();
                            }
                        }
                    }
                }
            }

            if (name != "")
            {
                foreach (var a in U)//проход по листу по имени
                {
                    if (a.name == name)
                        a1++;
                }                
                    foreach (var a2 in U)
                    {
                        if (a2.name == name)
                            U1.Add(a2);
                    }                
            }
            else
                U1 = U;

            if (surname != "")
            {
                foreach (var z in U1)//проход по листу по фамилии
                {
                    if (z.surname == surname)
                        b1++;
                }              
                    foreach (var b2 in U1)
                    {
                        if (b2.surname == surname)
                            U2.Add(b2);
                    }                
            }
            else
                U2 = U1;

            if (age != "")
            {
                foreach (var c in U2)//проход по листу по возрасту
                {
                    if (c.age == Convert.ToInt32(age))
                        c1++;
                }               
                    foreach (var c2 in U2)
                    {
                        if (c2.age == Convert.ToInt32(age))
                            U3.Add(c2);
                    }              
            }
            else
                U3 = U2;
            if (sex != "")
            {
                bool s = true;
                if (sex == "Male")
                    s = true;
                else
                    s = false;
                foreach (var d in U3)//проход по листу по полу
                {
                    if (d.sex == s)
                        d1++;
                }
                foreach (var d2 in U3)
                {
                    if (d2.sex == s)
                        U4.Add(d2);
                }
            }
            else
                U4 = U3;

            if (country != "")
            {
                foreach (var e in U4)//проход по листу по стране
                {
                    if (e.country == country)
                        e1++;
                }                
                    foreach (var e2 in U4)
                    {
                        if (e2.country == country)
                            U5.Add(e2);
                    }                
            }
            else
                U5 = U4;
            @ViewBag.Result = U5;
            return View("Search");
        }
    }
}
