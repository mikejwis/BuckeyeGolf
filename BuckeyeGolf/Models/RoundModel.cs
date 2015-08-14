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
        public Guid WeekId { get; set; }
        public int TotalScore { get; set; }
//        public List<int> Scores { get; set; }
//        public Guid PointId {get; set;}
        public double TotalPoints { get; set; }
//        public int BogeyCnt { get; set; }
//        public int ParCnt { get; set; }
        //        public int BirdieCnt { get; set; }
 //       [ForeignKey("PlayerId")]
        public Guid PlayerRefId { get; set; }

        [ForeignKey("PlayerRefId")]
        public PlayerModel PlayerRef { get; set; }
    }
}