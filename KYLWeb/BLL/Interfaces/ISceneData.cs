﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ISceneData
    {
        public List<Line> GetLines(int id);

        public Role AddRoleInDB(Role role);
    }
}
