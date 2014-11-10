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
        public void  updatepersonalinfo(string id, List<string> persinfo) //любое поле должно быть заполненым
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
            try
            {
                if (id != null)
                {
                
                    SqlCommand Update = new SqlCommand("UPDATE Users SET name = '" + persinfo[0] + "', surname='" + persinfo[1] + "', age='" + Convert.ToInt32(persinfo[2]) + "',sex='" + persinfo[3] + "', country='" + persinfo[4] + "' WHERE (h_name='" + id + "')", conn);

                    Update.ExecuteNonQuery();	   
                }
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
               conn.Close();
            }
           
           
        }
    }
}