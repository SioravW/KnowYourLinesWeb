using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KYLWeb.Models
{
    public class PlayViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        public String Title { get; set; }

        [Required(ErrorMessage = "A description is required")]
        public String Description { get; set; }

        public String Association { get; set; }

        public String Writer { get; set; }
    }
}
