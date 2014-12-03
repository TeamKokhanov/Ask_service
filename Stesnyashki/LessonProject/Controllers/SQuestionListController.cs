using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Questions;
using Stesnyashki.Models;

namespace Stesnyashki.Controllers
{
    public class SQuestionListController : Controller
    {
        //
        // GET: /QuestionList/

        public ActionResult Index()
        {
            ShyMeContext Sh = new ShyMeContext();
            //List<Question> QList = Q.QuestionListRetern(1);

            ViewBag.Question = Sh.Questions;
            return View(Sh.Questions);
        }
        [HttpPost]
        public ActionResult QuestionList() 
        {
            OuestionList Q = new OuestionList();
            ShyMeContext Sh = new ShyMeContext();
            //List<Question> QList = Q.QuestionListRetern(1);

            ViewBag.Question = Sh.Questions;
            return View("SQuestion");
        }

    }
}
