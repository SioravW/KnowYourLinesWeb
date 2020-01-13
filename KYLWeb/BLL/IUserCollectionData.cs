using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserCollectionData
    {
        public User GetUserById(int id);
    }
}
