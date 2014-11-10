using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace Lesson1.communication
{
    public class Comment
    {
        private void CommentButton_Click(object sender, EventArgs e)
        {
            CommentList.Visible = true;
        }
    }
}