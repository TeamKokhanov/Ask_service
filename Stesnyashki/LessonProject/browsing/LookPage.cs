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
        private void UserImage_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
           try
            {
               
               SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Users WHERE  (Users.id LIKE'%" + Convert.ToInt32(id.Text) + "%') ", conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                  name.Text = dataTable.Rows[1];
                  surname.Text = dataTable.Rows[2];
                  age.Text = dataTable.Rows[3];
                  sex.Text = dataTable.Rows[4];
                  country.Text = dataTable.Rows[5];
              
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
