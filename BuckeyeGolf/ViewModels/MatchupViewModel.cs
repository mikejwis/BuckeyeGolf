using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BuckeyeGolf.ViewModels
{
    public class MatchupSummaryViewModel
    {
        public int NextWeek { get; set; }
        public List<BasicPlayerViewModel> Players { get; set; }
        public List<MatchupWeekViewModel> Weeks { get; set; }
    }
    public class MatchupWeekViewModel
    {
        public int WeekNbr { get; set; }
        public List<MatchupViewModel> Matchups { get; set; }
    }

    public class MatchupViewModel
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Handicap { get; set; }
        public int Player2Handicap { get; set; }
    }


}