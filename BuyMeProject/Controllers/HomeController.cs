using BuyMeProject.Models;
using BuyMeProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IAccountService _accountService;
        IProductService _productService;
        SerializeService _serializeService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService, IProductService productService, SerializeService serializeService)
        {
            _logger = logger;
            _accountService = accountService;
            _productService = productService;
            _serializeService = serializeService;
        }

        public IActionResult Index()
        {
            ViewBag.PageHeader = "Home Page";
            var products = new List<Product>();
            return View(products);
        }

        public IActionResult Register()
        {
            ViewBag.PageHeader = "Register Page";
            if (Request.Cookies["userName"] != null) //Check if user is logged in
            {
                var user = _accountService.GetUser(Request.Cookies["userName"]);
                UserModel userModel = UserToUserModel(user);
                return View("Registration", userModel);
            }
            return View("Registration");
        }
        public IActionResult ShoppingCart()
        {
            var list = new List<Expenses>
            {
                new Expenses{home_mandatory=143, savings=4000,month="1",army_mandatory=123,army_pleasure=123,home_pleasure=23},
                new Expenses{home_mandatory=143, savings=4000,month="2",army_mandatory=123,army_pleasure=123,home_pleasure=123},
                new Expenses{home_mandatory=14, savings=3000,month="3",army_mandatory=13,army_pleasure=1234,home_pleasure=223},
                new Expenses{home_mandatory=143, savings=4000,month="4",army_mandatory=123,army_pleasure=123,home_pleasure=23},
                new Expenses{home_mandatory=143, savings=4000,month="5",army_mandatory=123,army_pleasure=123,home_pleasure=253},
            };
            return View("ShoppingCart");
        }

        private static UserModel UserToUserModel(User user)
        {
            return new UserModel
            {
            };
        }

        public IActionResult AddProduct()
        {
            ViewBag.PageHeader = "Add Expense Page";
            return View("AddExpense");
        }
        public IActionResult AboutUs()
        {
            ViewBag.PageHeader = "About Us Page";
            ViewBag.num = 60;
            ViewBag.Expenses = "1500";
            return View("AboutUs");
        }
        public IActionResult Suggestions()
        {
            ViewBag.PageHeader = "suggestions Page";
            return View("Suggestions");
        }
        public IActionResult Lessons()
        {
            ViewBag.PageHeader = "Lessons Page";
            return View("Lessons");
        }


        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
