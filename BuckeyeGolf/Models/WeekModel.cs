using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class WeekModel
    {
        [Key]
        public Guid WeekId { get; set; }
        [Required]
        public int WeekNbr { get; set; }
        public DateTime ScoreCreateDate { get; set; }
        public bool BeenPlayed { get; set; }
    }
}