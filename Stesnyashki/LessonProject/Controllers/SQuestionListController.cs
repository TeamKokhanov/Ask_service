using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Questions;
using Stesnyashki.Models;
using System.Data;

namespace Stesnyashki.Controllers
{
    public class SQuestionListController : Controller
    {
        //
        // GET: /QuestionList/
        ShyMeContext Sh = new ShyMeContext(); 
        public ActionResult Index()
        {
            ShyMeContext Sh = new ShyMeContext();
            ViewBag.Question = Sh.Questions;
            return View(Sh.Questions);
        }
        [HttpPost]
        public ActionResult QuestionList() 
        {
            List<User> UB = Sh.Users.Where(b => b.id == 1).ToList();
            foreach (var i in UB) 
            {
                ViewBag.Background = i.backgroundImage;
            }
            List<Question> QList = Sh.Questions.Where(q => q.idReciever == 1).ToList();
            List<Question> Q = new List<Question>();
            foreach (var i in QList) 
            {
                if (i.aText == null||i.aText=="") 
                {
                    Q.Add(i);
                }
            }
            if (Q.Count == 0)
                ViewBag.NullQuestion = "You don't have a question";
            ViewBag.Question = Q;
            List<string> NameList = new List<string>();
            foreach(var i in QList)
            {
                NameList.Add(Sh.Users.Find(i.idSender).name);
            }
            ViewBag.User = NameList;
            return View("SQuestion");
        }
        [HttpPost]
        public ActionResult Answer(int idQuestion,string aText) 
        {
            Question q = Sh.Questions.Find(idQuestion);
            q.aText = aText;
            q.aDate = DateTime.Now;
            Sh.Entry(q).State = EntityState.Modified;
            Sh.SaveChanges();
            return QuestionList();
        }
        [HttpPost]
        public ActionResult Delete(int id) 
        {
            Question q = Sh.Questions.Find(id);
            Sh.Questions.Remove(q);
            Sh.SaveChanges();
            return QuestionList();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            List<User> U = Sh.Users.Where(u => u.email == login).ToList();
            foreach (var i in U)
            {
                if (i.password == password)
                {
                    return QuestionList();
                }
            }
            return View("User");
        }
    }
}
