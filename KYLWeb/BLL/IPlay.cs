﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IPlay
    {
        public Play GetPlayById(int id);

        public List<Play> GetAllPlaysOfUser(User user);

        public Play AddPlayInDB(Play play);
    }
}
