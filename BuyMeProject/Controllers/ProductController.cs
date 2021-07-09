using BuyMeProject.Models;
using BuyMeProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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

namespace BuyMeProject.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        private readonly IConfiguration configuration;
        IAccountService _accountService;
        SerializeService _serializeService;
        string apiUrl;
        HttpClient client = new HttpClient();

        public ProductController(IProductService productService, IConfiguration configuration, IAccountService accountService, SerializeService serializeService)
        {
            apiUrl = configuration.GetValue(typeof(string), "ApiUrl") as string;
            _productService = productService;
            this.configuration = configuration;
            _accountService = accountService;
            _serializeService = serializeService;
        }

        [HttpPost]
        public IActionResult AddNewExpense(Expenses expense)
        {
            string str = JsonConvert.SerializeObject(expense);
            dynamic obj = JsonConvert.DeserializeObject(str);
            obj.user_id = Request.Cookies["userName"];
            var myContent = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string url = apiUrl + "/addNewExpense";
            var result = client.PostAsync(url, byteContent).Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            return View("~/Views/Home/Index.cshtml");
        }


       
    }
}
