using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Lesson1.DAL
{
    public class SQLConnector
    {
        SqlConnection sc;
        SqlCommand com;
        SqlDataReader dr;

        public SQLConnector()
        {
            sc = new SqlConnection();
            com = new SqlCommand();
            sc.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=LostNFoundDB.mdf;Integrated Security=True;Connect Timeout=30";
            com.Connection = sc;

        }

        private List<string> GetFieldTypes(string TableName, int argN)
        {
            com.CommandText = "select * from " + TableName + ";";
            sc.Open();
            dr = com.ExecuteReader();
            dr.Read();
            List<string> types = new List<string>();
            int j = (argN < dr.FieldCount) ? 1 : 0;
            for (; j < dr.FieldCount; j++)
            {
                types.Add(dr.GetDataTypeName(j));
            }
            sc.Close();
            return types;
        }
        private List<string> GetFieldTypes(string TableName, List<string> names)
        {
            com.CommandText = "select * from " + TableName + ";";
            sc.Open();
            dr = com.ExecuteReader();
            dr.Read();
            List<string> types = new List<string>();          
            for (int j = 0; j < dr.FieldCount; j++)
            {
                foreach (string name in names)
                {
                    if (name == dr.GetName(j))
                    {
                        types.Add(dr.GetDataTypeName(j));
                        break;
                    }
                }
            }
            sc.Close();
            return types;
        }
        private string FormAttrStr(string attr, string type)
        {
            string res = "";
            if (type == "nvarchar")
            {
                res += "N'";
            }
            if (type == "datetime")
            {
                res += "'";
            }
            res += attr;
            if (type == "nvarchar" || type == "datetime")
            {
                res += "'";
            }
            return res;
        }


        public DataTable strSelect(string command)
        {
            try
            {
                com.CommandText = command;
                sc.Open();
                dr = com.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                sc.Close();
                return t;
            }
            catch (Exception x)
            {
                //MessageBox.Show(x.Message.ToString());
                sc.Close();
                return null;
            }
        }
        public DataTable Select(string TableName)
        {
            try
            {
                com.CommandText = "select * from " + TableName + ";";
                sc.Open();
                dr = com.ExecuteReader();               
                DataTable t = new DataTable();
                t.Load(dr);
                sc.Close();
                return t;
            }
            catch (Exception x)
            {
                //MessageBox.Show(x.Message.ToString());
                sc.Close();
                return null;
            }
        }
        public DataTable Select(string TableName, string args)
        {
            try
            {
                com.CommandText = "select " + args + " from " + TableName + ";";
                sc.Open();
                dr = com.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                sc.Close();
                return t;
            }
            catch (Exception x)
            {
               // MessageBox.Show(x.Message.ToString());
                sc.Close();
                return null;
            }
        }
        public DataTable Select(string TableName, string args, string where)
        {
            try
            {
                com.CommandText = "select " + args + " from " + TableName + " where " + where + ";";
                sc.Open();
                dr = com.ExecuteReader();                                            
                DataTable t = new DataTable();
                t.Load(dr);
                sc.Close();
                return t;
            }
            catch (Exception x)
            {
               // MessageBox.Show(x.Message.ToString());
                sc.Close();
                return null;
            }
        }
        public DataTable Select(string TableName, string args, string where, string TableNameU, string argsU, string whereU)
        {
            try
            {
                com.CommandText = "select " + args + " from " + TableName + " where " + where;
                com.CommandText += " (select "+ argsU +" from " + TableNameU + " where " + whereU+");";
                sc.Open();
                dr = com.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                sc.Close();
                return t;
            }
            catch (Exception x)
            {
               // MessageBox.Show(x.Message.ToString());
                sc.Close();
                return null;
            }
        }

        public void Insert(string TableName, List<string> values)
        {
            List<string> types = GetFieldTypes(TableName, values.Count);
            try
            {
                com.CommandText = "insert into " + TableName + " values(";
                for (int i = 0; i < values.Count; i++)
                {
                    com.CommandText += FormAttrStr(values[i], types[i]);
                    if (i < values.Count - 1)
                    {
                        com.CommandText += ",";
                    }
                }
                com.CommandText += ");";
                sc.Open();
                com.ExecuteNonQuery();
                sc.Close();

            }
            catch (Exception x)
            {
                //MessageBox.Show(x.Message.ToString());
                sc.Close();
            }
        }       //fill the table with current values
        public void Update(string TableName, List<string> args, List<string> values, string where)
        {
            List<string> types = GetFieldTypes(TableName, args);
            try
            {
                com.CommandText = "update " + TableName + " set ";
                for (int i = 0; i < values.Count; i++)
                {
                    com.CommandText += args[i] + "="+FormAttrStr(values[i], types[i]);
                    
                    if (i < values.Count - 1)
                    {
                        com.CommandText += ",";
                    }
                }
                if (where != null)
                {
                    com.CommandText += " where "+ where;
                }
                com.CommandText += ";";
                sc.Open();
                com.ExecuteNonQuery();
                sc.Close();

            }
            catch (Exception x)
            {
                //MessageBox.Show(x.Message.ToString());
            }
        }

       /* public List<string> GetRealIDs(int id, string nick)
        {

            Item i = new Item(Select(" Items ", " * ", " Id = " + id), id);
            Query q = new Query(Select(" Querys ", " * ", " Id_Item = " + id), id);
            List<string> res = new List<string>();
            try
            {
                string command = "select i.Id from Items i, Querys q, Users u where u.Nickname = q.User_nick AND i.Id = q.Id_Item AND q.User_nick != N'" + nick + "' AND q.Resolved = 'false' AND Id_Match = 0 AND q.Lost = '";
                if (q.gLost)
                {
                    command += "false' AND i.Date > '" + i.gDate.ToString("yyyyMMdd HH:mm") + "'";
                }
                else
                {
                    command += "true' AND i.Date < '" + i.gDate.ToString("yyyyMMdd HH:mm") + "'";
                }
                command += " AND i.Id_Kind = " + i.gId_Kind;

                if (i.gPers_Num != "")
                {
                    command += " AND i.Pers_Num = N'" + i.gPers_Num + "' ";
                }

                if (q.gLost)
                {
                    UserData ud = new UserData(Select(" Users ", " Name,Surname,Fathername ", "Nickname = N'" + nick + "'"));
                    command += " AND (i.OName = N'" + ud.gName + "' OR i.OName = N'') ";
                    command += " AND (i.OSName = N'" + ud.gSName + "' OR i.OSName = N'') ";
                    command += " AND (i.OFName = N'" + ud.gFName + "' OR i.OFName = N'') ";
                }
                else
                {
                    if (i.gOName != "")
                    {
                        command += " AND u.Name = N'" + i.gOName + "' ";
                    }
                    if (i.gOSName != "")
                    {
                        command += " AND u.Surname = N'" + i.gOSName + "' ";
                    }
                    if (i.gOFName != "")
                    {
                        command += " AND u.Fathername = N'" + i.gOFName + "' ";
                    }
                }
                command += ";";
                DataTable dt = strSelect(command);
                foreach (DataRow dr in dt.Rows)
                {
                    res.Add(dr["Id"].ToString());
                }
                return res;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
                return res;
            }
        }       
*/
        
        public void CloseCon()
        {
            sc.Close(); 
        }
    }
}