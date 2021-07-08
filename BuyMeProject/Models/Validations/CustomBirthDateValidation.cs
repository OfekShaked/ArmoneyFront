using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class CustomBirthDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = Convert.ToDateTime(value);
                if (date!=null&&date.Year>1900&&date.Year<DateTime.Now.Year)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Date is invalid");
        }
    }
}
