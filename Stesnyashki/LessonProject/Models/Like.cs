﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson1.Models
{
    public class Like
    {
        public int idQuestion { get; set; }

        public int idComment { get; set; }

        public int idUser { get; set; }
    }
}