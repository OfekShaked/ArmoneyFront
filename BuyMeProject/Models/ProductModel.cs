using Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Short description cannot be empty")]
        [StringLength(500,ErrorMessage = "Short description max length must be under 500")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Long description cannot be empty")]
        [StringLength(4000, ErrorMessage = "Short description max length must be under 4000")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        [CustomPriceValidation]
        public decimal Price { get; set; }
        public IFormFile Picture1 { get; set; }
        public IFormFile Picture2 { get; set; }
        public IFormFile Picture3 { get; set; }
    }
}
