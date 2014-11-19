using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Lesson1.statistic
{
    public class Statistic
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\admin\Desktop\WindowsFormsApplication1\WindowsFormsApplication1\ShyMeDB.mdf;Integrated Security=True");
        public string CountLikes(int userId)//подсчет кол-ва лайков
        {
            conn.Open();
            int lq, lc, sum;
            SqlDataAdapter LikesQ = new SqlDataAdapter("SELECT Sum(Questions.likes) As clikesq From Questions,Users Where Users.id=Questions.idReciever AND Users.id=" + userId, conn);
            DataTable dataTable = new DataTable();
            LikesQ.Fill(dataTable);
            lq = Convert.ToInt32(dataTable.Rows[0]["clikesq"]);

            SqlDataAdapter LikesC = new SqlDataAdapter("SELECT Sum(Comments.likes) As clikesc From Comments,Users Where Users.id=Comments.idSender AND Users.id=" + userId, conn);
            LikesC.Fill(dataTable);
            lc = Convert.ToInt32(dataTable.Rows[1]["clikesc"]);

            sum = lq + lc;
            conn.Close();
            return sum.ToString();

        }
        public string CountQuestions(int userId)//подсчет кол-ва заданых вопросов
        {
            conn.Open();
            SqlDataAdapter QuestionsC = new SqlDataAdapter("Select Count(Questions.id) As cquest From Questions, Users Where Users.id= Questions.idReciever And Users.id=" + userId, conn);
            DataTable dataTable = new DataTable();
            QuestionsC.Fill(dataTable);
            conn.Close();
            return dataTable.Rows[0]["cquest"].ToString();
        }
        public string CountAnswers(int userId)//подсчет кол-ва даных ответов
        {
            conn.Open();
            SqlDataAdapter AnswersC = new SqlDataAdapter("Select Count(Questions.aText) As cansw From Questions, Users Where Users.id= Questions.idReciever AND Questions.aText IS NOT NULL AND Users.id=" + userId, conn);
            DataTable dataTable = new DataTable();
            AnswersC.Fill(dataTable);
            conn.Close();
            return dataTable.Rows[0]["cansw"].ToString();
        }
    }
}