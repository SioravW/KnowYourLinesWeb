﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Scene
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Number { get; set; }
        public List<Line> Lines { get; set; }
    }
}
