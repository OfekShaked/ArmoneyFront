using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth date is required")]
        [CustomBirthDateValidation]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [CustomUsernameValidation]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Validation password is required")]
        [Compare("Password",ErrorMessage ="Passwords must be identical")]
        public string PasswordValidator { get; set; }

    }
}
