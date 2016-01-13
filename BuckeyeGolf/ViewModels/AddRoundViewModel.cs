﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ViewModels
{
    public class AddRoundWeekViewModel
    {
        public int WeekNbr { get; set; }
        public Guid WeekId { get; set; }
        [Required]
        public string FrontBack { get; set; }
        public List<AddRoundViewModel> PlayerRounds { get; set; }
    }

    public class AddRoundViewModel
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public List<int> Scores { get; set; }
    }
}