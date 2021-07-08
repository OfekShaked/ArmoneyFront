using BuyMeProject.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class CustomUsernameValidation : ValidationAttribute
    {
        IAccountService _accountService;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _accountService = (IAccountService)validationContext.GetService(typeof(IAccountService));
            if (value != null)
            {
                if (_accountService.IsUsernameAvailable(value.ToString()))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Username already exist");
        }


    }
}
