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
        public int Birds { get; set; }
        public int Pars { get; set; }
        public int Bogeys { get; set; }
    }

    public class LeaderboardViewModel
    {
        public int WeeksPlayed { get; set; }
        public List<PlayerLeaderboardViewModel> FirstHalfPlayerSummary { get; set; }
        public List<PlayerLeaderboardViewModel> SecondHalfPlayerSummary { get; set; }
    }
}