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
            var products = _productService.GetAllAvailableProducts();
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

        private static UserModel UserToUserModel(User user)
        {
            return new UserModel
            {
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public IActionResult AddProduct()
        {
            ViewBag.PageHeader = "Add Product Page";
            return View("AddProduct");
        }
        public IActionResult AboutUs()
        {
            ViewBag.PageHeader = "About Us Page";
            return View("AboutUs");
        }
        public IActionResult ShoppingCart()
        {
            ViewBag.PageHeader = "Shopping Cart Page";
            List<Product> productsOnCart = new List<Product>();
            var username = Request.Cookies["userName"];
            if (username != null)
            {
                productsOnCart = _accountService.GetProductsByUser(username); //Get logged in person cart
            }
            else
            {
                //Get guest cart if exist
                var guestCart = Request.Cookies["guestCart"];
                if (guestCart != null)
                {
                    var cartProductIds = (List<long>)_serializeService.StringToObject(guestCart);
                    productsOnCart = _productService.GetProductsOfGuestByIds(cartProductIds);
                }
            }
            return View("ShoppingCart", productsOnCart);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
