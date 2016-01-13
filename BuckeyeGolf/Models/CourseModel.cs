using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class CourseModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public List<Par> FrontPars { get; set; }
        [Required]
        public List<Par> BackPars { get; set; }
    }

    public class Par
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParValue { get; set; }

        public bool Front { get; set; }

        [Required]
        public Guid CourseRefId { get; set; }

        [ForeignKey("CourseRefId")]
        public virtual CourseModel CourseRef { get; set; }
    }
}