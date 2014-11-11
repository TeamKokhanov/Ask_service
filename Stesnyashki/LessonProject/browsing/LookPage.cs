using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;



namespace stesnyashki
{
    public class LookPage//просмотр страницы зарегистрированного пользователя
    {
       public void MakePage(int idPerson)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
           try
            {

                //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Users.name As N,Users.surname As S,Usesr.age As A,Usesr.Sex As Se,Users.Country As C FROM Users WHERE  (Users.id LIKE'%" + idPerson + "%') GROUP BY Users.name,Users.surname,Users.age,Users.sex,Users.country", conn);
                //DataTable dataTable = new DataTable();
                //dataAdapter.Fill(dataTable);
                //name.Text = Convert.ToString(dataTable.Rows[0]["N"]);
                //surname.Text = Convert.ToString(dataTable.Rows[0]["S"]);
                //age.Text = Convert.ToString(dataTable.Rows[0]["A"]);
                //sex.Text = Convert.ToString(dataTable.Rows[0]["Se"]);
                //country.Text = Convert.ToString(dataTable.Rows[0]["C"]);
              
           }
           catch (Exception ex)
           {
          
           }
           finally
           {
               conn.Close();
           }
        }
        }
    }
