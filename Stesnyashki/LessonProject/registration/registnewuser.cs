using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using Stesnyashki.Models;
using Stesnyashki.DAL;

namespace Stesnyashki
{
    public class registnewuser //класс регистрации
    {      

        public bool regist(string email, string password, string confpassword) 
        {
            SQLConnector SQC = new SQLConnector();
            DataTable dt = SQC.strSelect("select Max(id) from User;");
            int maxid = Convert.ToInt32( dt.Rows[0][0]);
           ShyMeContext Sh = new ShyMeContext();                 
            Random r = new Random();
            if (password == confpassword)
            {
                User u = new User
                {
                    id = maxid+1,
                    email=email,
                    password = password

                };
                try
                {
                    Sh.Users.Add(u);
                    return true;
                }
                catch(Exception e){
                    return false;
                }
            }
            return false;
        }

        private int maxvalue(List<int> idlist) 
        {
            int maxvalue = 0;
            foreach (var i in idlist) 
            {
                if (i > maxvalue)
                    maxvalue = i;
            }
            return maxvalue;
        }
    }
}