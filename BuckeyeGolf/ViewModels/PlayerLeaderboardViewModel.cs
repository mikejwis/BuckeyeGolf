using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class PlayerLeaderboardViewModel
    {
        public double ScoreAvg { get; set; }
        public string Name { get; set; }
        public double TotalPoints { get; set; }
        public int CurrentHandicap { get; set; }
 //       public int BackScrAvg { get; set; }
 //       public int FrontScrAvg { get; set; }
    }
}