using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    [Serializable]
    public class LoginModel
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        [CustomLoginValidation("Password")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
