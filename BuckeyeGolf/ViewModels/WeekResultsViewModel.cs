using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class WeekResultsViewModel
    {
        public int WeekNbr { get; set; }
        public List<PlayerRoundViewModel> PlayerRounds { get; set; }
        public DateTime ScoreCreateDate { get; set; }
    }

    public class PlayerRoundViewModel
    {
        public string Name { get; set; }
        public string PlayerId { get; set; }
        public int TotalScore { get; set; }
        public double TotalPoints { get; set; }
        public int Pars { get; set; }
        public int Birdies { get; set; }
        public int Bogeys { get; set; }
    }
}