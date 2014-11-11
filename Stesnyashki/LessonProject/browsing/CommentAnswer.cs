using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace Lesson1.browsing
{
    public class CommentAnswer
    {
        public  void ShowCommentA(string Answer)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
            try
            {
         SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Question.id AS qid FROM Question WHERE   (Question.aText LIKE'%" + Answer + "%') ", conn);//выбор инфы по вопросам
         DataTable dataTable = new DataTable();
         dataAdapter.Fill(dataTable);
         int a = Convert.ToInt32(dataTable.Rows[0]["qid"]);
         if (a != 0 && Answer != "")
         {
             //CommentBox.Visible = true;
         }
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