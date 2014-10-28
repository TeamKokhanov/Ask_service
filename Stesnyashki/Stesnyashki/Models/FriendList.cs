public class FriendList
    {
        MySqlConnection mySqlConn;
        DataTable dt = new DataTable();

        public FriendList(string strConn = "server=localhost;database=Stesnyashki;userid=regUser;password=0000")
        {
            MySqlConnection mySqlConn = new MySqlConnection(strConn);
        }

        public int add(string uid, string fuid)
        {
            mySqlConn.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT friendList FROM Users WHERE id = " + uid, mySqlConn);
            mySqlDataAdapter.Fill(dt);
            string friendList = (string)dt.Rows[0][8];
            if (friendList.IndexOf(fuid) != -1) return 0;
            string toAdd = friendList == "" ? fuid : "," + fuid;
            mySqlDataAdapter = new MySqlDataAdapter("UPDATE Users SET friendList = '" + (friendList + toAdd) + "' WHERE id = " + uid, mySqlConn);
            mySqlConn.Close();

            return 1;
        }
    }
