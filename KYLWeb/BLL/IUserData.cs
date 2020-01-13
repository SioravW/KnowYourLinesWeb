using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserData
    {
        public Play GetPlayById(int id);

        public List<Play> GetAllPlays(User user);

        public Play AddPlayInDB(Play play);
    }
}
