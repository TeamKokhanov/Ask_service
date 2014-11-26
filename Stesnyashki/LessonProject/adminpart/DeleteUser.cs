using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Lesson1.adminpart
{
    public class DeleteUser
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\admin\Desktop\WindowsFormsApplication2\WindowsFormsApplication2\ShyMeDB.mdf;Integrated Security=True");
        public void DeleteUserAction(int adminId, int userId)
        {
            conn.Open();
            if (adminId == -1)
            {
                SqlCommand del = new SqlCommand("DELETE FROM [Users] Where Users.id = @id", conn);
                del.Parameters.AddWithValue("@id", userId);
                del.ExecuteNonQuery();
                SqlCommand del1 = new SqlCommand("DELETE FROM [Questions] Where Qustions.idReciever = @id", conn);
                del1.Parameters.AddWithValue("@id", userId);
                del1.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}