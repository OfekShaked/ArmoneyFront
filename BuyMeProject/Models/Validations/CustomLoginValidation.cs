using BuyMeProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class CustomLoginValidation : ValidationAttribute
    {
        IAccountService _accountService;
        private readonly string _password;
        public CustomLoginValidation(string passwordProperty)
        {
            _password = passwordProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_password);
            string password="";
            if(property!=null)
            {
                var passwordProperty = property.GetValue(validationContext.ObjectInstance, null);
                if(passwordProperty!=null)
                {
                    password = passwordProperty.ToString();
                }    
            }
            if(password=="")
            {
                return new ValidationResult("Incorrect username or password");
            }
            _accountService = (IAccountService)validationContext.GetService(typeof(IAccountService));
            if (_accountService.ConfirmLogin(value.ToString(),password))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Incorrect username or password");
            }
        }
    }
}
