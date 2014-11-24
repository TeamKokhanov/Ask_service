using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using Stesnyashki.DAL;
using Stesnyashki.Models;

namespace Stesnyashki.UserWorker
{
    public class Personalpageupdate
    {
        SQLConnector sq = new SQLConnector();

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=ShyMeDB.mdf;Integrated Security=True");

        public void ChangeBG(int userId, string newbg)
        {
            List<string> args = new List<string>();
            List<string> values = new List<string>();
            args.Add("backgroundImage");
            values.Add(newbg);
            sq.Update("Users", args, values, "(Users.id='" + userId + "')");
            ShyMeContext Sh = new ShyMeContext();
          
            
            foreach (var i in Sh.Users)
            {
                User u = new User();
            if(u.id==userId)
            {
                u.backgroundImage = newbg;
            }
            }

        }
        public void ChangeMude(int userId, string mude)
        {
            List<string> args = new List<string>();
            List<string> values = new List<string>();
            args.Add("mude");
            values.Add(mude);
            sq.Update("Users", args, values, "(Users.id='" + userId + "')");
            ShyMeContext Sh = new ShyMeContext();
            foreach (var i in Sh.Users)
            {
                User u = new User();
                if (u.id == userId)
                {
                  //  u.mude = mude;
                }
            }

        }
        public void PersonalInfoUpdate(int userId, List<string> persinfo)
        {
            conn.Open();
            if (userId != 0)
            {
                SqlCommand Update = new SqlCommand("UPDATE Users SET Users.name = '" + persinfo[0] + "', Users.surname='" + persinfo[1] + "', Users.age='" + Convert.ToInt32(persinfo[2]) + "', Users.sex='" + persinfo[3] + "', Users.country='" + persinfo[4] + "', Users.email='" + persinfo[5] + "', Users.password='" + persinfo[6] + "', Users.avatar='" + persinfo[7] + "', Users.isDataOpened='" + persinfo[8] + "' WHERE (Users.id='" + userId + "')", conn);
                Update.ExecuteNonQuery();
            }
            ShyMeContext Sh = new ShyMeContext();
            foreach (var i in Sh.Users)
            {
                User u = new User();
                if (u.id == userId)
                {
                    u.name = persinfo[0];
                    u.surname = persinfo[1];
                    u.age = Convert.ToInt32 (persinfo[2]);
                    u.sex = Convert.ToBoolean (persinfo[3]);
                    u.country = persinfo[4];
                    u.email = persinfo[5];
                    u.password = persinfo[6];
                    u.avatar = persinfo[7];
                    u.isDataOpened = Convert.ToBoolean(persinfo[8]);
                }
            }
            conn.Close();
        }
        public bool Privacy(int userId)
        {
            bool a;

            DataTable dataTable = sq.Select("Users","isDataOpened AS privacy");
            a = Convert.ToBoolean(dataTable.Rows[0]["privacy"]);
            return a;

        }
    }
}