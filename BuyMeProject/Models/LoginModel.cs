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
        [CustomLoginValidation("password")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string password { get; set; }
    }
}
