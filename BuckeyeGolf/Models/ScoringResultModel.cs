using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class ScoringResultModel
    {
        public int Bogeys { get; set; }
        public int Pars { get; set; }
        public int Birdies { get; set; }
        public int Eagles { get; set; }
        public double Points { get; set; }
    }
}