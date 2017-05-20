using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class WeeklyRoundViewModel
    {
        public int WeekNbr { get; set; }
        public int Score { get; set; }
        public double Points { get; set; }
        public int Bogeys { get; set; }
        public int Pars { get; set; }
        public int Birdies { get; set; }
        public string MatchResult { get; set; }
    }
}