using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace stesnyashki
{
    public class registnewuser //класс регистрации
    {
        public string regist(string login, string password, string confpassword) 
        {            
            List<string> loginlist = new List<string>();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=!!!!!;Integrated Security=True");//подключение к БД
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlcont = new SqlDataAdapter();
            sqlcont = new SqlDataAdapter("Select Login From Regist Where Login Like '%" + login + "%'", conn);//поменять название поля и таблицы в БД
            sqlcont.Fill(dt);
            loginlist = dt.AsEnumerable().Select(r => r.Field<string>("Login")).ToList();
            sqlcont = new SqlDataAdapter("Select Max(Id) From Regist", conn);//поменять название поля и таблицы в БД
            sqlcont.Fill(dt);
            int maxid = dt.AsEnumerable().Select(r => r.Field<int>("Login")).ToList()[0];
            foreach (var i in loginlist) 
            {
                if (i == login)
                    return "Пользователь с таким логином уже зарегистророван";
            }
            if (password == confpassword)
            {
                SqlCommand sq1 = new SqlCommand("Insert into Regist(Id,Login,Password) values(@Id,@Login,@Password)", conn);//поменять название поля и таблицы в БД
                sq1.Parameters.AddWithValue("@Id", 1);
                sq1.Parameters.AddWithValue("@Login", login);
                sq1.Parameters.AddWithValue("@Password", password);
                try
                {
                    sq1.ExecuteNonQuery();
                    conn.Close();
                    return "Регистрация проведена успешно!";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else return "Пароли не совпадают!";           
        }
    }
}