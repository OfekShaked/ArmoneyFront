using BuyMeProject.Models;
using BuyMeProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IAccountService _accountService;
        SerializeService _serializeService;

        public ProductController(IProductService productService, IAccountService accountService, SerializeService serializeService)
        {
            _productService = productService;
            _accountService = accountService;
            _serializeService = serializeService;
        }
        public IActionResult AddProduct(ProductModel productModel)
        {
            if (ModelState.IsValid) //New Proudct is valid
            {
                var userId = _accountService.GetUserId(Request.Cookies["userName"]);
                Product newProduct = ProductModelToProduct(productModel, userId);
                List<string> base64Imgs = ImagesToBase64(productModel);
                AddBase64ToProduct(newProduct, base64Imgs);
                _productService.AddNewProduct(newProduct);
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/AddProduct.cshtml", productModel);

        }
        public IActionResult AddProductToCart(string username, string productId)
        {
            if (long.TryParse(productId, out long prodId)) //Check if product id is a long
            {
                List<long> guestCartItems = GetGuestCartItemsIfExist();
                if (_productService.AddProductToBasket(prodId, _accountService.GetUserId(username), guestCartItems))
                {
                    if (username == null)
                    {
                        AddProductToGuestCartCookie(prodId);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        private List<long> GetGuestCartItemsIfExist()
        {
            var guestCartString = Request.Cookies["guestCart"];
            List<long> guestCartItems = null;
            if (guestCartString != null)
            {
                guestCartItems = (List<long>)_serializeService.StringToObject(guestCartString);
            }

            return guestCartItems;
        }

        public IActionResult ProductDetails([FromQuery(Name = "productId")] string productId = null)
        {
            ViewBag.PageHeader = $"Product Number {productId} Page";
            if (long.TryParse(productId, out long idFound))
            {
                var productFound = _productService.GetProduct(idFound);
                if (productFound != null)
                {
                    return View("~/Views/Home/ProductDetails.cshtml", productFound);
                }
            }
            return ReturnToPreviousOrDefaultPage();
        }

        private IActionResult ReturnToPreviousOrDefaultPage()
        {
            var previousUrl = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(previousUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(previousUrl);
            }
        }

        public IActionResult BuyProducts()
        {
            var username = Request.Cookies["userName"];
            if (username != null)
            {
                _productService.BuyProductsOfLoggedUser(username);
            }
            else
            {
                var guestCartItems = GetGuestCartItemsIfExist();
                if (guestCartItems != null)
                {
                    _productService.BuyProductsOfGuest(guestCartItems);
                    Response.Cookies.Delete("guestCart");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveProductFromCart(string productId)
        {
            if (long.TryParse(productId, out long prodId))
            {
                _productService.RemoveProductFromBasket(prodId);
                var userName = Request.Cookies["userName"];
                if (userName == null)
                {
                    var guestCartItems = GetGuestCartItemsIfExist();
                    if (guestCartItems != null)
                    {
                        guestCartItems.Remove(prodId);
                        CreateNewCartCookie(_serializeService.ObjectToString(guestCartItems));
                    }
                }
                return Json(new { redirectToUrl = Url.Action("ShoppingCart", "Home") });
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SortProductsBy(string sortByType = null)
        {
            ViewBag.PageHeader = "Home Page";
            var products = _productService.GetAllAvailableProducts(sortByType);
            return View("~/Views/Home/Index.cshtml", products);
        }
        private void AddProductToGuestCartCookie(long productId)
        {
            var guestCart = Request.Cookies["guestCart"];
            string cartString;
            List<long> productsInCart;
            if (guestCart == null)
            {
                productsInCart = new List<long>();
                cartString = AddNewProductToCartString(productId, productsInCart);
            }
            else
            {
                productsInCart = (List<long>)_serializeService.StringToObject(guestCart);
                cartString = AddNewProductToCartString(productId, productsInCart);
            }
            CreateNewCartCookie(cartString);
        }

        private void CreateNewCartCookie(string cartString)
        {
            Response.Cookies.Delete("guestCart");
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.Add(PublicGeneralProperties.CartProductExpirationDate);
            Response.Cookies.Append("guestCart", cartString, option);
        }

        private string AddNewProductToCartString(long productId, List<long> productsInCart)
        {
            string cartString;
            productsInCart.Add(productId);
            cartString = _serializeService.ObjectToString(productsInCart);
            return cartString;
        }

        private static void AddBase64ToProduct(Product newProduct, List<string> base64Imgs)
        {
            switch (base64Imgs.Count)
            {
                case 1: newProduct.Picture1 = base64Imgs[0]; break;

                case 2:
                    newProduct.Picture2 = base64Imgs[1];
                    newProduct.Picture1 = base64Imgs[0]; break;

                case 3:
                    newProduct.Picture3 = base64Imgs[2];
                    newProduct.Picture2 = base64Imgs[1];
                    newProduct.Picture1 = base64Imgs[0]; break;
            }
        }

        private static void IFormFileToBase64(List<IFormFile> files, List<string> base64Imgs)
        {
            foreach (var file in files)
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            base64Imgs.Add(s);
                        }
                    }
                }
            }
        }
        private static List<string> ImagesToBase64(ProductModel productModel)
        {
            List<string> base64Imgs = new List<string>();
            List<IFormFile> files = new List<IFormFile> { productModel.Picture1, productModel.Picture2, productModel.Picture3 };
            IFormFileToBase64(files, base64Imgs);
            return base64Imgs;
        }

        private static Product ProductModelToProduct(ProductModel productModel, long? userId)
        {
            return new Product
            {
                LongDescription = productModel.LongDescription,
                ShortDescription = productModel.ShortDescription,
                Title = productModel.Title,
                OwnerId = userId,
                Price = productModel.Price
            };
        }
    }
}
