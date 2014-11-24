using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stesnyashki.DAL;

namespace Lesson1.statistic
{
    public class Statistic
    {
        SQLConnector sq = new SQLConnector();
        public string CountLikes(int userId)//подсчет кол-ва лайков
        {

            int lq, lc, sum;
            DataTable dataTable = sq.strSelect("SELECT Sum(Questions.likes) As clikesq From Questions,Users Where Users.id=Questions.idReciever AND Users.id=" + userId);
            lq = Convert.ToInt32(dataTable.Rows[0]["clikesq"]);

            DataTable dataTable1 = sq.strSelect("SELECT Sum(Comments.likes) As clikesc From Comments,Users Where Users.id=Comments.idSender AND Users.id=" + userId);
            lc = Convert.ToInt32(dataTable1.Rows[0]["clikesc"]);

            sum = lq + lc;
            sq.CloseCon();
            return sum.ToString();

        }
        public string CountQuestions(int userId)//подсчет кол-ва заданых вопросов
        {
            DataTable dataTable = sq.strSelect("Select Count(Questions.id) As cquest From Questions, Users Where Users.id= Questions.idReciever And Users.id=" + userId);
            return dataTable.Rows[0]["cquest"].ToString();
        }
        public string CountAnswers(int userId)//подсчет кол-ва даных ответов
        {
            DataTable dataTable = sq.strSelect("Select Count(Questions.aText) As cansw From Questions, Users Where Users.id= Questions.idReciever AND Questions.aText IS NOT NULL AND Users.id=" + userId);
            return dataTable.Rows[0]["cansw"].ToString();
        }
    }
}