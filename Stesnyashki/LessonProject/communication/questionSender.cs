	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Data.OleDb;
	using System.Data.SqlClient;
	using System.Data;
	
	namespace Stesnyashki
	{
	    public class questionSender //класс отправки вопроса пользователю
	    {
	        public bool sendQuestion(int idSender, int idRerciever, string Text) //любое поле должно быть заполненым
	        {
	            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Дмитрий\Documents\GitHub\Ask_service\Stesnyashki\Stesnyashki\bin\StesnyashkiDB\StesnyashkiDB\StesnyashkiDB.dbmdl;Integrated Security=True");//подключение к БД
	            conn.Open();	        
	            SqlCommand cmd = new SqlCommand("INSERT INTO Questions" +
	                     " values (@idSender,@idRerciever,@qText,@qDate,null,null,s0) ", conn); //название полей поменять в БД
	            cmd.Parameters.AddWithValue("@idSender", idSender);
	            cmd.Parameters.AddWithValue("@idRerciever", idRerciever);
				cmd.Parameters.AddWithValue("@qText",Text);
	            cmd.Parameters.AddWithValue("@qDate", DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss"));//ToDo: watch the right transformation!!!!
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