using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace stesnyashki
{
    public class Personalpageupdate
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\admin\Desktop\WindowsFormsApplication2\WindowsFormsApplication2\ShyMeDB.mdf;Integrated Security=True");
        public void ChangeBG(int userId, string newbg)
        {
            conn.Open();
            SqlCommand Update = new SqlCommand("UPDATE Users SET Users.backgroundImage = '" + newbg + "' WHERE (Users.id='" + userId + "')", conn);

            Update.ExecuteNonQuery();
            conn.Close();

        }
        public void ChangeMude(int userId, string mude)
        {
            conn.Open();
            SqlCommand Update = new SqlCommand("UPDATE Users SET Users.mude = '" + mude + "' WHERE (Users.id='" + userId + "')", conn);
            Update.ExecuteNonQuery();
            conn.Close();
        }
        public void PersonalInfoUpdate(int userId, List<string> persinfo)
        {
            conn.Open();
            if (userId != 0)
            {
                SqlCommand Update = new SqlCommand("UPDATE Users SET Users.name = '" + persinfo[0] + "', Users.surname='" + persinfo[1] + "', Users.age='" + Convert.ToInt32(persinfo[3]) + "', Users.sex='" + persinfo[4] + "', Users.country='" + persinfo[5] + "', Users.email='" + persinfo[6] + "', Users.password='" + persinfo[7] + "', Users.avatar='" + persinfo[8] + "', Users.isDataOpened='" + persinfo[9] + "' WHERE (Users.id='" + userId + "')", conn);
                Update.ExecuteNonQuery();
            }
            conn.Close();
        }
        public bool Privacy(int userId)
        {
            bool a;
            conn.Open();
            SqlDataAdapter Priv = new SqlDataAdapter("SELECT Users.isDataOpened AS privacy FROM Users", conn);
            DataTable dataTable = new DataTable();
            Priv.Fill(dataTable);
            a = Convert.ToBoolean(dataTable.Rows[0]["privacy"]);
            conn.Close();
            return a;

        }
    }
}