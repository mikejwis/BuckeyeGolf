using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class CourseModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public ArrayList FrontPars { get; set; }
        [Required]
        public ArrayList BackPars { get; set; }
    }
}