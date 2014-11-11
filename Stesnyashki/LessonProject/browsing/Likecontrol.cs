using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Lesson1.browsing
{
    public class Likecontrol
    {
        public int likeanswer(int idAnswer,int idUser) 
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
            int countlikes = 0;
            try
            {
                SqlDataAdapter aqc = new SqlDataAdapter("Select idUser From Likes Where idQuestion=" + Convert.ToString(idAnswer), conn);
                DataTable dt = new DataTable();
                aqc.Fill(dt);
                List<int> users = dt.AsEnumerable().Select(r => r.Field<int>("idUser")).ToList();
                foreach (var i in users) 
                {
                    if (i == idUser)
                    {
                        try
                        {
                            SqlCommand sc = new SqlCommand("Delete From Likes where idQuestion=@id", conn);
                            sc.Parameters.AddWithValue("@id", idAnswer);
                            sc.ExecuteNonQuery();
                            
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else 
                    {
                        try
                        {
                            SqlCommand updata = new SqlCommand("Insert into Likes (idQuestion,idComment,idUser) Values(@idA,idC,@idU)", conn);
                            updata.Parameters.AddWithValue("@idA", idAnswer);
                            updata.Parameters.AddWithValue("@idC", null);
                            updata.Parameters.AddWithValue("@idU", idUser);
                            updata.ExecuteNonQuery();
                            
                        }
                        catch (Exception e) 
                        {
                            
                        }
                    }
                }
                SqlDataAdapter sdq = new SqlDataAdapter("Select Count(idUser) From Likes Where idQuestion=" + Convert.ToString(idAnswer), conn);
                DataTable countdt = new DataTable();
                sdq.Fill(countdt);
                return Convert.ToInt32(countdt.Rows[1]);
            }
            catch (Exception e)
            {
                return countlikes;
            }
            finally 
            {
                conn.Close();
            }
        } //like answer return count of like if user do doubleclick delete like and return count of like

        public int likecomment(int idComment, int idUser)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
            conn.Open();
            int countlikes = 0;
            try
            {
                SqlDataAdapter aqc = new SqlDataAdapter("Select idUser From Likes Where idComment=" + Convert.ToString(idComment), conn);
                DataTable dt = new DataTable();
                aqc.Fill(dt);
                List<int> users = dt.AsEnumerable().Select(r => r.Field<int>("idUser")).ToList();
                foreach (var i in users)
                {
                    if (i == idUser)
                    {
                        try
                        {
                            SqlCommand sc = new SqlCommand("Delete From Likes where idComment=@id", conn);
                            sc.Parameters.AddWithValue("@id", idComment);
                            sc.ExecuteNonQuery();

                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else
                    {
                        try
                        {
                            SqlCommand updata = new SqlCommand("Insert into Likes (idQuestion,idComment,idUser) Values(@idA,idC,@idU)", conn);
                            updata.Parameters.AddWithValue("@idA", null);
                            updata.Parameters.AddWithValue("@idC", idComment);
                            updata.Parameters.AddWithValue("@idU", idUser);
                            updata.ExecuteNonQuery();

                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                SqlDataAdapter sdq = new SqlDataAdapter("Select Count(idUser) From Likes Where idComment=" + Convert.ToString(idComment), conn);
                DataTable countdt = new DataTable();
                sdq.Fill(countdt);
                return Convert.ToInt32(countdt.Rows[1]);
            }
            catch (Exception e)
            {
                return countlikes;
            }
            finally
            {
                conn.Close();
            }
        } //like comment return count of like if user do doubleclick delete like and return count of like

   
    }
}