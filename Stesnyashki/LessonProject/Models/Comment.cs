using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stesnyashki.Models
{
    public class Comment
    {
        public int id { get; set; }

        public int idQuestion { get; set; }

        public string text { get; set; }

        public DateTime date { get; set; }

        public int like { get; set; }

        public int idSender { get; set; }
    }
}