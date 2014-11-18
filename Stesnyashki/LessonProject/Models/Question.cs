using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stesnyashki.Models
{
    public class Question
    {
        public int id { get; set; }

        public int idSender { get; set; }

        public int idResiver { get; set; }

        public string qText { get; set; }

        public DateTime qDate { get; set; }

        public string aText { get; set; }

        public DateTime aDate { get; set; }

        public int like { get; set; }

        public bool anonymus { get; set; }
    }
}