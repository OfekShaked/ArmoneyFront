using BuyMeProject.Models;
using BuyMeProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuyMeProject.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        SerializeService _serializeService;
        HttpClient client = new HttpClient();
        string apiUrl;


        public AccountController(IAccountService accountService, SerializeService serializeService
            ,
            IConfiguration configuration)
        {
            apiUrl = configuration.GetValue(typeof(string), "ApiUrl") as string;
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
            var myContent = JsonConvert.SerializeObject(newUser);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync(apiUrl + "/signup", byteContent).Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            //User is valid add to cookies and continue to main page.
            //LoginToCookie(newUser.UserName);
            User newUserAccount = UserModelToUser(newUser);
            _accountService.Register(newUserAccount);
            return RedirectToAction("Index", "Home");
        }

        private static User UserModelToUser(UserModel newUser)
        {
            return new User
            {
                Email = newUser.email,
                FirstName = newUser.first_name,
                LastName = newUser.last_name,
                Password = newUser.password
            };
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                TempData["loginModel"] = _serializeService.ObjectToString(login);
                return ReturnToPreviousPageOrDefault();
            }
            var myContent = JsonConvert.SerializeObject(new { email = login.email, password = login.password });
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync(apiUrl + "/login", byteContent).Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            dynamic d = JObject.Parse(responseContent);
            LoginToCookie(d.user_id.ToString()); //login Succecfully
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
