using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class MatchupModel
    {
        [Key]
        public Guid MatchupId { get; set; }
        public Guid Player1 { get; set; }
        public Guid Player2 { get; set; }
        public Guid WeekId { get; set; }
    }
}