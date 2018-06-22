using BuckeyeGolf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class PlayerViewModel
    {
        public Guid PlayerId { get; set; }
        public ICollection<RoundModel> Rounds { get; set; }
        public string Name { get; set; }
        public int HandicapRound1 { get; set; }
        public int HandicapRound2 { get; set; }
    }
}