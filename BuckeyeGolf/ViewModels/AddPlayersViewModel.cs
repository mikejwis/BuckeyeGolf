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
        public int StartingHandicap { get; set; }
    }
}