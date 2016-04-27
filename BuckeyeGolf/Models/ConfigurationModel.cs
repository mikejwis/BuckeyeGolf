using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class ConfigurationModel
    {
        [Key]
        public Guid LeagueId { get; set; }
        public int HandicapWeekCount { get; set; }
        public int RoundParFront { get; set; }
        public int RoundParBack { get; set; }
        public double RoundAdjustment { get; set; }
    }
}