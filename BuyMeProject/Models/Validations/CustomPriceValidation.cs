using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class CustomPriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((decimal)value>=0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Price must be above 0");
        }
    }
}
