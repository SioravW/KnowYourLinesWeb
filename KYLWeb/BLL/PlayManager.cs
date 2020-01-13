using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PlayManager
    {
        IPlay play;

        public PlayManager(IPlay play)
        {
            this.play = play;
        }

        public Play GetPlayById(int id)
        {
            return play.GetPlayById(id);
        }

        public List<Play> GetAllPlaysOfUser(User user)
        {
            return play.GetAllPlaysOfUser(user);
        }

        public Play AddPlayInDB(Play play)
        {
            return this.play.AddPlayInDB(play);
        }
    }
}
