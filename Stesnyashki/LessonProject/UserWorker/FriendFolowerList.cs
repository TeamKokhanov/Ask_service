using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Stesnyashki.UserWorker
{
    public class FriendFolowerList
    {
       // SQLConnector sq = new SQLConnector();
        //public List<int> FriendList(int id) 
        //{
        //    List<int> FriendList = new List<int>();

        // //   DataTable friend = sq.Select("User", "friendList", "id=" + Convert.ToString(id));
        //   // string friends = Convert.ToString(friend.AsEnumerable().Select(r => r.Field<string>("friendList")).ToList()[0]);
        // //   friends+='#';
        //    int count=0;
        //    while (friends[count] != '#') 
        //    {
        //        int i=count;
        //        string idfriends = "";
        //        while (friends[i] != ';') 
        //        {
        //            idfriends += friends[i];
        //            i++;
        //        }
        //        FriendList.Add(Convert.ToInt32(idfriends));
        //        count = i + 1;
        //    }
        //    return FriendList;
        //}

        //public List<int> FollowersList(int id)
        //{
        //    List<int> FollowersList = new List<int>();

        //    DataTable followers = sq.Select("User", "followList", "id=" + Convert.ToString(id));
        //    string follower = Convert.ToString(followers.AsEnumerable().Select(r => r.Field<string>("followList")).ToList()[0]);
        //    follower += '#';
        //    int count = 0;
        //    while (follower[count] != '#')
        //    {
        //        int i = count;
        //        string idfollower = "";
        //        while (follower[i] != ';')
        //        {
        //            idfollower += follower[i];
        //            i++;
        //        }
        //        FollowersList.Add(Convert.ToInt32(idfollower));
        //        count = i + 1;
        //    }
        //    return FollowersList;
        //}
    }
}