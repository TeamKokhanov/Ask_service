﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson1.Models
{
    public class Question
    {
        public int id { get; set; }

        public int idSender { get; set; }

        public int idResiver { get; set; }

        public string qText { get; set; }

        public DateTime qDate { get; set; }

        public string aText { get; set; }

        public int like { get; set; }
    }
}