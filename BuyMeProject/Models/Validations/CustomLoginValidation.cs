using BuyMeProject.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class CustomLoginValidation : ValidationAttribute
    {
        IAccountService _accountService;
        private readonly string _password;
        private readonly HttpClient client = new HttpClient();
        string apiUrl;
        public CustomLoginValidation(string passwordProperty)
        {
            apiUrl = "http://localhost:3000";
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

            var myContent = JsonConvert.SerializeObject(new  {Email= value.ToString(),Password= password});
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync(apiUrl + "/login", byteContent).Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            if (responseContent != "Internal Server Error")
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
