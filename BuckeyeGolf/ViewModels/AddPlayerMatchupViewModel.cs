using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class AddPlayerMatchupViewModel
    {
        [Required]
        public int NextWeek { get; set; }
        [Required]
        public List<BasicPlayerViewModel> Players { get; set; }
    }
}