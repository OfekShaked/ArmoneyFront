using BuyMeProject.Models;
using BuyMeProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuyMeProject.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        SerializeService _serializeService;
        public AccountController(IAccountService accountService, SerializeService serializeService)
        {
            _accountService = accountService;
            _serializeService = serializeService;
        }
        [HttpPost]
        public IActionResult Register(UserModel newUser)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.PageHeader = "Registration Page";
                return View("~/Views/Home/Registration.cshtml", newUser); //New user is not valid return to same page with errors.
            }
            //User is valid add to cookies and continue to main page.
            LoginToCookie(newUser.UserName);
            User newUserAccount = UserModelToUser(newUser);
            _accountService.Register(newUserAccount);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(UserModel userToUpdate)
        {
            if (String.IsNullOrWhiteSpace(userToUpdate.Password)) //Check if password is empty if it is dont change it
            {
                ModelState.Remove("Password");
                ModelState.Remove("PasswordValidator");
            }
            ModelState.Remove("UserName");
            userToUpdate.UserName = Request.Cookies["userName"];
            if(!ModelState.IsValid)
            {
                ViewBag.PageHeader = "Update User Page";
                return View("~/Views/Home/Registration.cshtml", userToUpdate);
            }
            //Update user if everything is ok.
            User updatedUser = UserModelToUser(userToUpdate);
            _accountService.UpdateUser(updatedUser);
            return RedirectToAction("Index", "Home");
        }
        private static User UserModelToUser(UserModel newUser)
        {
            return new User
            {
                UserName = newUser.UserName,
                BirthDate = newUser.BirthDate,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Password = newUser.Password
            };
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if(!ModelState.IsValid)
            {
                TempData["loginModel"] = _serializeService.ObjectToString(login);
                return ReturnToPreviousPageOrDefault();
            }
            LoginToCookie(login.UserName); //login Succecfully
            return ReturnToPreviousPageOrDefault();
        }

        private IActionResult ReturnToPreviousPageOrDefault()
        {
            var previousUrl = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(previousUrl)) //Check if there is a previous page to return to.
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(previousUrl);
            }
        }

        private void LoginToCookie(string username)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Append("userName", username, option);
        }
        public IActionResult Logout(string controller, string action)
        {
            Response.Cookies.Delete("userName");
            return RedirectToAction(action, controller);
        }
    }
}
