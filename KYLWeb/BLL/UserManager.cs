using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class UserManager
    {
        IUser user;

        public UserManager(IUser user)
        {
            this.user = user;
        }

        public User GetUserById(int id)
        {
            return user.GetUserById(id);
        }
    }
}
