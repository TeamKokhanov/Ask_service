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
            List<Question> QList = Sh.Questions.Where(q => q.idReciever == 1).ToList();
            ViewBag.Question = QList;
            List<string> NameList = new List<string>();
            foreach(var i in QList)
            {
                NameList.Add(Sh.Users.Find(i.idSender).name);
            }
            ViewBag.User = NameList;
            return View("SQuestion");
        }

    }
}
