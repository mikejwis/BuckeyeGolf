using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class RoundModel
    {
        [Key]
        public Guid RoundId { get; set; }
        public bool Front { get; set; }
        [Required]
        public Guid WeekId { get; set; }
        public int TotalScore { get; set; }
        public List<Score> Scores { get; set; }
        public double TotalPoints { get; set; }
        public int EagleCnt { get; set; }
        public int BogeyCnt { get; set; }
        public int ParCnt { get; set; }
        public int BirdieCnt { get; set; }
        public int Handicap { get; set; }
        [Required]
        public Guid PlayerRefId { get; set; }

        [ForeignKey("PlayerRefId")]
        public virtual PlayerModel PlayerRef { get; set; }
    }

    public class Score
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ScoreValue { get; set; }
    }
}