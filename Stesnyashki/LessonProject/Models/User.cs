using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stesnyashki.Models
{
    public class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string surname { get; set; }

        public int age { get; set; }

        public bool sex { get; set; }

        public string country { get; set; }

        public List<int> friendlist { get; set; }

        public List<int> followlist { get; set; }
    }
}