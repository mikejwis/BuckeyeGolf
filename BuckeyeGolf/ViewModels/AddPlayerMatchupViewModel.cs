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
        public int WeekNbr { get; set; }
        [Required]
        public List<Guid> Player1Id { get; set; }
        [Required]
        public List<Guid> Player2Id { get; set; }
    }
}