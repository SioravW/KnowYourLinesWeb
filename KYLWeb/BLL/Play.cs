using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Play
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int AssociationId { get; set; }
        public int WriterId { get; set; }
        public List<Scene> Scenes { get; set; }
        public List<Role> Roles { get; set; }

        readonly IPlayData playData;

        public Play(IPlayData playData)
        {
            this.playData = playData;
        }
        public Play() {  }
        public Role GetRoleById(int id)
        {
            return playData.GetRoleById(id);
        }

        public Scene GetSceneById(int id)
        {
            return playData.GetSceneById(id);
        }

    }
}
