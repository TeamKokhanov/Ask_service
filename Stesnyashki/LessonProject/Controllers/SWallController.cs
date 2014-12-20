using Stesnyashki.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// DAUBUR_KIRILL
//This class is created to load  the user Page, when it is referenced in View


namespace Stesnyashki.Controllers
{

    public class SWallController : Controller
    {
        ShyMeContext sh = new ShyMeContext();

        [HttpGet]
        public ActionResult GoToUserWall(int id)
        {            
            User u = sh.Users.Find(id);            
            if (u != null)
            {
                //Session["curId"] = u.id;
                ViewBag.CurUser = u;
                List<Question> query = sh.Questions.Where(q => q.idReciever == id).ToList();
                List<Question> qList = new List<Question>();

                ViewBag.StatQuestions = countQuestions(u.id);
                ViewBag.StatLikes = countLikes(u.id);

                foreach (Question q in query)
                {
                    if (q.aText != null)
                    {
                        qList.Add(q);
                    }
                }
                List<Comment> comments = new List<Comment>();
                List<User> qUsers = new List<User>();
                List<User> cUsers = new List<User>();
                foreach (Question q in qList)
                {
                    List<Comment> temp = sh.Comments.Where(c => c.idQuestion == q.id).ToList();
                    comments.AddRange(temp);
                    foreach (Comment c in temp)
                    {
                        User r = sh.Users.Find(c.idSender);
                        cUsers.Add(r);
                    }
                    if (q.anonymus)
                    {
                        qUsers.Add(null);
                    }
                    else
                    {
                        qUsers.Add(sh.Users.Find(q.idSender));
                    }

                }
                ViewBag.QuestionList = qList;
                ViewBag.CommentList = comments;
                ViewBag.cUsers = cUsers;
                ViewBag.qUsers = qUsers;
                return View("../SWall/UserWall");
            }
            else
                return new HttpStatusCodeResult(404);
        }

        //-------------Likes-------------------------------

        [HttpGet]
        public ActionResult likeQuestion(int id)
        {
            int myId = Convert.ToInt32(Session["id"]);
            Question q = sh.Questions.Find(id);
            if (q != null)
            {
                List<Like> likeList = sh.Likes
                    .Where(l => l.idUser == myId).ToList();
                foreach (Like l in likeList)
                {
                    if (l.idQuestion == id && l.idComment == -1)
                    {
                        sh.Likes.Remove(l);
                        q.likes -= 1;
                        sh.Entry(q).State = EntityState.Modified;
                        sh.SaveChanges();
                        return/*Redirect(Request.UrlReferrer.ToString());*/GoToUserWall(Convert.ToInt32(Session["id"])); //View("~/Views/Some/UserWall.cshtml");
                    }
                }
                Like like = new Like();

                like.idComment = -1;
                like.idQuestion = q.id;
                like.idUser = myId;
                sh.Likes.Add(like);

                q.likes += 1;
                sh.Entry(q).State = EntityState.Modified;
                sh.SaveChanges();
                return /*Redirect(Request.UrlReferrer.ToString()); */GoToUserWall(Convert.ToInt32(Session["id"])); //View("~/Views/Some/UserWall.cshtml");
            }
            return new HttpStatusCodeResult(404); //TODO: return some error page!!!
        }

        [HttpGet]
        public ActionResult likeComment(int id)
        {
            int myId = Convert.ToInt32(Session["id"]);
            Comment c = sh.Comments.Find(id);
            int q = -1;

            if (c != null)
            {
                q = sh.Questions.Find(c.idQuestion).id;
            }

            if (q != -1)
            {
                List<Like> likeList = sh.Likes
                    .Where(l => l.idUser == myId).ToList();
                foreach (Like l in likeList)
                {
                    if (l.idQuestion == q && l.idComment == id)
                    {
                        sh.Likes.Remove(l);
                        c.likes -= 1;
                        sh.Entry(c).State = EntityState.Modified;
                        sh.SaveChanges();
                        return /*Redirect(Request.UrlReferrer.ToString()); */GoToUserWall(Convert.ToInt32(Session["id"]));//View("~/Views/Some/UserWall.cshtml");
                    }
                }
                Like like = new Like();

                like.idComment = id;
                like.idQuestion = q;
                like.idUser = myId;
                sh.Likes.Add(like);

                c.likes += 1;
                sh.Entry(c).State = EntityState.Modified;
                sh.SaveChanges();
                return/* Redirect(Request.UrlReferrer.ToString());*/GoToUserWall(Convert.ToInt32(Session["id"])); //View("~/Views/Some/UserWall.cshtml");
            }
            return new HttpStatusCodeResult(404); //TODO: return some error page!!!
        }

        //--------------------------------------------------

        [HttpPost]
        public ActionResult addComment(Comment c)
        {
            c.date = DateTime.Now;
            c.likes = 0;
            c.idSender = Convert.ToInt32(Session["id"]);
            sh.Comments.Add(c);
            sh.SaveChanges();
            return GoToUserWall(49);
        }


        //----------------Asking----------------------------

        private void SendQuestion(Question q, ShyMeContext sh)
        {
            sh.Questions.Add(q);
            sh.SaveChanges();
        }

        [HttpPost]
        public ActionResult ask(Question q)
        {
            q.idSender = Convert.ToInt32(Session["id"]);
            q.idReciever = 49;
            q.qDate = DateTime.Now;
            q.aText = null;
            q.aDate = Convert.ToDateTime("01.01.1753 00:00:00");
            SendQuestion(q, sh);
            return Redirect(Request.UrlReferrer.ToString());
        }

        //--------------------------------------------------
       
        
        //---------------Statistics--------------

        private int countQuestions(int id)
        {
            List<Question> Q = sh.Questions.Where(b => b.idReciever == id).ToList();
            //int count = 0;
            //foreach (var i in Q)
            //{
            //    if (i.idReciever == id)
            //    {
            //        count++;
            //    }
            //}

            return Q.Count;
        }

        private int countLikes(int id)
        {
            List<Question> Q = sh.Questions.Where(b => b.idReciever == id).ToList();
            int count = 0;
            foreach (var i in Q)
            {
                if (i.idReciever == id)
                {
                    count += Convert.ToInt32(i.likes);
                }

            }

            return count;
        }

        //---------------------------------------
        [HttpPost]
        public ActionResult follow(int id) 
        {
            User U = sh.Users.Find(Convert.ToInt32(Session["id"]));
            string followers = U.friendlist;
            if (U.friendlist == null || U.friendlist == "")
            {
                U.friendlist += Convert.ToString(id) + ';';
                sh.Entry(U).State = EntityState.Modified;
                sh.SaveChanges();
                return GoToUserWall(Convert.ToInt32(Session["id"]));
            }
            else 
            {
                U.friendlist += Convert.ToString(id) + ';';
                sh.Entry(U).State = EntityState.Modified;
                sh.SaveChanges();
                return GoToUserWall(Convert.ToInt32(Session["id"]));
            }
            
            return GoToUserWall(Convert.ToInt32(Session["id"])); 
            
        }
    }
}
