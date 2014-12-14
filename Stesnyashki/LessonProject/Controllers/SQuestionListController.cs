using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            int id = Convert.ToInt32(Session["id"]);
            List<User> UB = Sh.Users.Where(b => b.id == id).ToList();
            foreach (var i in UB) 
            {
                ViewBag.Background = i.backgroundImage;
            }
            List<Question> QList = Sh.Questions.Where(q => q.idReciever == id).ToList();
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
            List<string> avatar = new List<string>();
            foreach(var i in Q)
            {
                
                if (i.anonymus)
                {
                    avatar.Add("/Content/anonymous.png");
                    NameList.Add("Anonymous");
                }
                else
                {
                    avatar.Add(Sh.Users.Find(i.idSender).avatar);
                    NameList.Add(Sh.Users.Find(i.idSender).name);
                }
            }
            ViewBag.User = NameList;
            ViewBag.avatar = avatar;
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

        
    }
}
