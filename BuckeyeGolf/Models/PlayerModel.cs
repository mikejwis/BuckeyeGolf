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
        public string Name { get; set; }
    }
}