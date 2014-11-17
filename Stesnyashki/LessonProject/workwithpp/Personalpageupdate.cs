using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace Stesnyashki
{
    public class Personalpageupdate
    {
        public void  updatepersonalinfo(int id) //оба  поля должны быть заполнеными
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
            //if (id != 0)
            //{
            //    try
            //    {
            //        if (id != null)
            //        {

            //            SqlCommand Update = new SqlCommand("UPDATE Users SET name = '" + changeN.Text + "', surname='" + changeS.Text + "', age='" + Convert.ToInt32(changeA.Text) + "',sex='" + changeSe.Text + "', country='" + changeC.Text + "' WHERE (Users.id='" + id + "')", conn);

            //            Update.ExecuteNonQuery();
            //        }
            //    }
            //    catch (SqlException ex)
            //    {

            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
            //else 
            //{
            //    Warning.Text = "Current user is not exist in this website";
            //}
           
        }
    }
}