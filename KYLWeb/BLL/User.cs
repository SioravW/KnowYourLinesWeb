using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class User
    {
        public int Id { get; set;  }
        public String FullName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public List<Play> Plays { get; set; }
        public List<int> Associations { get; set; }

        
    }
}
