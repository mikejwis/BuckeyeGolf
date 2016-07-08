using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class AddNewPlayerMatchupViewModel
    {
        [Required]
        public int WeekNbr { get; set; }
        [Required]
        public List<NewPlayerMatchup> NewPlayerMatchups { get; set; }
    }

    public class NewPlayerMatchup
    {
        [Required]
        public Guid Player1Id { get; set; }
        [Required]
        public Guid Player2Id { get; set; }
    }
}