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
    }
}
