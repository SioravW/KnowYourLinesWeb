using BLL.Interfaces;
using System;
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

        readonly ISceneData sceneData;

        public Scene(ISceneData sceneData)
        {
            this.sceneData = sceneData;
        }
        public Scene() { }

        public List<Line> GetLines(int id)
        {
            return sceneData.GetLines(id);
        }

        public Role AddRoleInDB(Role role)
        {
            return sceneData.AddRoleInDB(role);
        }
    }
}
