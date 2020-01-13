using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserCollection
    {
        IUserCollectionData userCollection;
        public List<User> Users { get; set; }

        public UserCollection(IUserCollectionData userCollection)
        {
            this.userCollection = userCollection;
        }
        public User GetUserById(int id)
        {
            return userCollection.GetUserById(id);
        }
    }
}
