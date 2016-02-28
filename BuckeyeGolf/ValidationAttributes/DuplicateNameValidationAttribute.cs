using BuckeyeGolf.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.ValidationAttributes
{
    public class DuplicateNameValidationAttribute : ValidationAttribute
    {
        public DuplicateNameValidationAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (var repoProvider = new RepoProvider())
            {
                string newName = value.ToString().Trim();
                var playerFound = repoProvider.PlayerRepo.Get(newName);
                if(playerFound != null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return null;
        }
    }
}