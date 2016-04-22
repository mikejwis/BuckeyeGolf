using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class PlayercardViewModel
    {
        public string Name { get; set; }
        public int Handicap { get; set; }
        public double AvgScore { get; set; }
        public int SeasonHigh { get; set; }
        public int SeasonLow { get; set; }
        public double TotalPoints { get; set; }
        public double WeeklyAvgPoint { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public List<int> Scores { get; set; }
        public IEnumerable<string> Players { get; set; }

    }
}