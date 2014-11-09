using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;



namespace Stesnyashki.browsing
{
    public class LookPage//просмотр страницы зарегистрированного пользователя
    {
        private void UserImage_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
           try
            {
                 SqlCommand cmd = new SqlCommand("Update Users" +
                     " Set name = @Name, surname=@Sername, age=@Age, sex=@Gender, country=@Country where id = @Id ", conn);
           // SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Users WHERE  (@Name LIKE'%" + Name.Text + "%') AND (@Surname LIKE'%" + Surname.Text + "%') ", conn);
                DataTable dataTable = new DataTable();
               // dataAdapter.Fill(dataTable);
               // UserListInfo.DataSource = dataTable;
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
