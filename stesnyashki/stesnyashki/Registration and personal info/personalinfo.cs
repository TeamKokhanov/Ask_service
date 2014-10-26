using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace stesnyashki
{
    public class personalinfo //класс добавления личных данных имя, фамилия, возраст, пол
    {
        public bool addpersonalinfo(string id, string login, List<string> persinfo) //любое поле должно быть заполненым
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=!!!!!;Integrated Security=True");//подключение к БД
            conn.Open();
            if (id != null)
            {
                SqlCommand cmd = new SqlCommand("Update Reistr" +
                     " Set Name = @Name, Sername=@Sername, Age=@Age, Gender=@Gender, Country=@Country where Id = @Id ", conn); //название полей поменять в БД
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", persinfo[0]);
                cmd.Parameters.AddWithValue("@Sername", persinfo[1]);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(persinfo[2]));
                cmd.Parameters.AddWithValue("@Gender", persinfo[3]);
                cmd.Parameters.AddWithValue("@Country", persinfo[4]);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else if (login != null)
            {
                SqlCommand cmd = new SqlCommand("Update Reistr" +
                     " Set Name = @Name, Sername=@Sername, Age=@Age, Gender=@Gender, Country=@Country where Login = @Login ", conn);//название полей поменять в БД
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Name", persinfo[0]);
                cmd.Parameters.AddWithValue("@Sername", persinfo[1]);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(persinfo[2]));
                cmd.Parameters.AddWithValue("@Gender", persinfo[3]);
                cmd.Parameters.AddWithValue("@Country", persinfo[4]);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else return false;
        }
    }
}