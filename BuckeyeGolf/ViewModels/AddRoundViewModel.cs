using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class AddRoundWeekViewModel
    {
        public int WeekNbr { get; set; }
        public Guid WeekId { get; set; }
        public string FrontBack { get; set; }
        public List<AddRoundViewModel> PlayerRounds { get; set; }
    }

    public class AddRoundViewModel
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public double Points { get; set; }
        public int Score { get; set; }
        public int Birdies { get; set; }
        public int Pars { get; set; }
        public int Bogeys { get; set; }
    }
}