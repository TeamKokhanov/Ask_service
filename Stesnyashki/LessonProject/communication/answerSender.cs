	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Data.OleDb;
	using System.Data.SqlClient;
	using System.Data;
	
	namespace stesnyashki
	{
	    public class answerSender //this class adds an answer to a concrete question
	    {
	        public bool sendAnswer(int idQuestion, string aText) 
	        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
	            conn.Open();
	           
	                SqlCommand cmd = new SqlCommand("Update Questions" +
	                     " Set aText = @aText, aDate=@aDate where id = @Id ", conn); 
	                cmd.Parameters.AddWithValue("@Id", idQuestion);
	                cmd.Parameters.AddWithValue("@aText", aText);
	                cmd.Parameters.AddWithValue("@aDate", DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss")); //check DateTime formation

	                try
	                {
	                    cmd.ExecuteNonQuery();	                    
	                    return true;
	                }
	                catch (Exception e)
	                {
	                    return false;
	                }
					finally
					{
						conn.Close();
					}
	        }
	    }
	}