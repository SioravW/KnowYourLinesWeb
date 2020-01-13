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
        
        IUserData userData;

        public User(IUserData userData)
        {
            this.userData = userData;
        }

        public User()
        {

        }

        public Play GetPlayById(int id)
        {
            return userData.GetPlayById(id);
        }

        public List<Play> GetAllPlaysOfUser(User user)
        {
            return userData.GetAllPlays(user);
        }

        public Play AddPlayInDB(Play play)
        {
            return this.userData.AddPlayInDB(play);
        }

    }
}
