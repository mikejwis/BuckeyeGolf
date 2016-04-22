using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BuckeyeGolf.ValidationAttributes;

namespace BuckeyeGolf.ViewModels
{
    public class AddPlayersViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        [DuplicateNameValidation(ErrorMessage="Player with this name already exists")]
        public string Name { get; set; }
        [Required]
        [Range(0,99)]
        public int HandicapR1Score { get; set; }
        public int HandicapR2Score { get; set; }
        public IEnumerable<string> Players { get; set; }
    }
}