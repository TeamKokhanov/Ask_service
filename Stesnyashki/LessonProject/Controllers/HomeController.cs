﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;

namespace Lesson1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create() 
        {

            return null;
        }
    }
}
