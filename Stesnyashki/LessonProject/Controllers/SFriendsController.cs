using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stesnyashki.Models;
using System.Data;

namespace Stesnyashki.Controllers
{
    public class SFriendsController : Controller
    {
        //
        // GET: /SFriends/
        ShyMeContext Sh = new ShyMeContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUserFriends() 
        {
            int id = Convert.ToInt32(Session["id"]);
            SFriendsController SF = new SFriendsController();
            List<User> UB = Sh.Users.Where(b => b.id == 1).ToList();// cookies id
            User U = new User();
            string friendlist="";
            foreach (var i in UB) 
            {
                friendlist = i.friendlist;
            }
            List<int> FriendList = new List<int>();
            friendlist += '#';
            int count = 0;
            while (friendlist[count] != '#')
            {
                int i = count;
                string idfriends = "";
                while (friendlist[i] != ';')
                {
                    idfriends += friendlist[i];
                    i++;
                }
                FriendList.Add(Convert.ToInt32(idfriends));
                count = i + 1;
            }
            ViewBag.Friendsid = FriendList;
            List<string> name = new List<string>();
            List<string> avatar = new List<string>();
            List<int> countFriends = new List<int>();
            List<int> countAnswers = new List<int>();
            foreach (var i in FriendList) 
            {
                User UB1 = Sh.Users.Where(b => b.id == i).FirstOrDefault();
                name.Add(UB1.name +"  "+ UB1.surname);
                if (UB1.avatar == "" || UB1.avatar == null)
                    avatar.Add("/Content/avatar.png");
                else
                    avatar.Add(UB1.avatar);
                countFriends.Add(SF.countFriends(i));
                countAnswers.Add(SF.countAnswers(i));
            }
            ViewBag.name = name;
            ViewBag.avatar = avatar;
            ViewBag.countFriends = countFriends;
            ViewBag.countAnswers = countAnswers;
            ViewBag.countthisuserFriends = SF.countFriends(1);//cookies id
            return View("SFriend");
        }

        private int countFriends(int id) 
        {
            User UB1 = Sh.Users.Where(b => b.id == id).FirstOrDefault();
            string friendlist = UB1.friendlist;
            List<int> FriendList = new List<int>();
            friendlist += '#';
            int count = 0;
            while (friendlist[count] != '#')
            {
                int i = count;
                string idfriends = "";
                while (friendlist[i] != ';')
                {
                    idfriends += friendlist[i];
                    i++;
                }
                FriendList.Add(Convert.ToInt32(idfriends));
                count = i + 1;
            }
            return FriendList.Count;
        }

        private int countAnswers(int id) 
        {
            List<Question> Q = Sh.Questions.Where(b => b.idReciever == id).ToList();
            int count = 0;
            foreach (var i in Q) 
            {
                if (i.aText != null || i.aText != "") 
                {
                    count++;
                }
            }

            return count;
        }
    }
}
