using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class PlayerModel
    {   
        [Key]
        public Guid PlayerId { get; set; }
        public virtual ICollection<RoundModel> Rounds { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Range(0, 99)]
        public int HandicapRound1 { get; set; }
        [Required]
        [Range(0, 99)]
        public int HandicapRound2 { get; set; }
    }
}