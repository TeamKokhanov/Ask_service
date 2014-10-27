using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stesnyashki.Models
{
    public class StatisticInformtion
    {
        SqlConnection conn;
        public StatisticInformtion(string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\"+
            @"Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\"+
            @"StesnyashkiDB.dbmdl;Integrated Security=True")
        {
            conn = new SqlConnection(ConnectionString);//подключение к БД
        }
        public int GetLikes(int userId)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlcont = new SqlDataAdapter();
            sqlcont = new SqlDataAdapter("TODO"
                //String.Format("select count(likes.id) from questions, users where user.id='{0}' and user.id = question.idReciever", userId)
                , conn);
            sqlcont.Fill(dt);
            conn.Close();
            return (int)dt.Rows[0][0];
            return 0;
        }
        public int Questions(int userId)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlcont = new SqlDataAdapter();
            sqlcont = new SqlDataAdapter(
                String.Format("select count(questions.id) from questions, users where user.id='{0}' and user.id = question.idReciever", userId), conn);
            sqlcont.Fill(dt);
            conn.Close();
            return (int)dt.Rows[0][0];
        }
        public int Answers(int userId)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlcont = new SqlDataAdapter();
            sqlcont = new SqlDataAdapter(
                String.Format("select count(questions.id) from questions, users where user.id='{0}' and user.id = question.idSender", userId), conn);
            sqlcont.Fill(dt);
            conn.Close();
            return (int)dt.Rows[0][0];
        }

    }
}