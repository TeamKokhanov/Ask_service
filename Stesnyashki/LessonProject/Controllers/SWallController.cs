using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;

namespace Stesnyashki.Controllers
{
    public class SWallController : Controller
    {
        //
        // GET: /SWall/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string CountLikes(int id)//метод для для подсчета кол-ва лайков пользователя находится на стене пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();
            int sum = 0;
            if (id == null)
            {
                return "User with this id isn`t exist";
            }
            else
            {
                foreach (Question q in Sh.Questions)
                {
                    if (q.idReciever == id)
                    {
                        sum += Convert.ToInt32(q.likes);
                    }

                }

            }
           
            return sum.ToString();
        }

        [HttpPost]
        public string CountQuestions(int id)//метод для для подсчета кол-ва вопросов заданных пользователю  находится на стене пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();

            int sum = 0;
            if (id == null)
            {
                return "User with this id isn`t exist";
            }
            else
            {
                foreach (Question q in Sh.Questions)
                {
                    if (q.idReciever == id)
                    {
                        sum++;
                    }

                }

            }
            return sum.ToString();
        }


        [HttpPost]
        public string CountAnswers(int id)//метод для для подсчета кол-ва ответов пользователя находится на стене пользователя made by Valera
        {
            ShyMeContext Sh = new ShyMeContext();
            int sum = 0;
            if (id == null)
            {
                return "User with this id isn`t exist";
            }
            else
            {
                foreach (Question q in Sh.Questions)
                {
                    if (q.idReciever == id && q.aText != null)
                    {
                        sum++;
                    }

                }

            }
            return sum.ToString();
        }
    }
}
