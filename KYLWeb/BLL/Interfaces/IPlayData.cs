using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IPlayData
    {
        public Role GetRoleById(int id);
        public Scene GetSceneById(int id);
    }
}
