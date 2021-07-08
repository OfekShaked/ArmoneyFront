using Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;

namespace BuyMeProject.Services
{
    public class ProductService : IProductService
    {
        DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }



        public bool AddNewProduct(Product newProduct)
        {
            if (ValidateProductData(newProduct) == false) return false;
            try
            {
                newProduct.State = ProductStatus.ForSale;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return true;
        }
            catch(Exception e)
            {
                return false;
            }
}

        public bool AddProductToBasket(long productID, long? userId, List<long> guestProductIds=null)
        {
            if (UpdateProductStatus(ProductStatus.Unnvailable, productID, out Product productUpdated))
            {
                try
                {
                    productUpdated.UserId = userId;
                    var currentTime = DateTime.Now;
                    productUpdated.BasketExpirationDate = currentTime.Add(PublicGeneralProperties.CartProductExpirationDate);
                    if (guestProductIds != null)
                    {
                        foreach (var productId in guestProductIds)
                        {
                            //update expiration date
                            _context.Products.FirstOrDefault(p => p.Id.Equals(productId)).BasketExpirationDate = currentTime.Add(PublicGeneralProperties.CartProductExpirationDate);
                        }
                    }
                    _context.Products.Update(productUpdated);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    UpdateProductStatus(ProductStatus.ForSale, productID, out productUpdated);
                    return false;
                }
            }
            return false;

        }

        private void BuyProduct(Product productToBuy)
        {

            UpdateProductStatus(ProductStatus.Sold, productToBuy.Id, out Product product);
        }

        public List<Product> GetAllAvailableProducts(string orderByProperty=null)
        {
            if (orderByProperty == null) orderByProperty = "";
            try
            {
                switch(orderByProperty.ToLower())
                {
                    case "price":
                        return _context.Products.Where(p => p.State == ProductStatus.ForSale).OrderBy(p=>p.Price).ToList();
                    case "title":
                        return _context.Products.Where(p => p.State == ProductStatus.ForSale).OrderBy(p => p.Title).ToList();
                    case "date":
                        return _context.Products.Where(p => p.State == ProductStatus.ForSale).OrderBy(p => p.Date).ToList();
                    default:
                        return _context.Products.Where(p => p.State == ProductStatus.ForSale).ToList();
                }               
            }
            catch
            {
                return new List<Product>();
            }
        }

        public Product GetProduct(long productID)
        {
            try
            {
                return _context.Products.Include(u=>u.Owner).FirstOrDefault(p => p.Id.Equals(productID));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool RemoveProductFromBasket(long productID)
        {
            if (UpdateProductStatus(ProductStatus.ForSale, productID, out Product productUpdated))
            {
                try
                {
                    productUpdated.UserId = null;
                    productUpdated.BasketExpirationDate = null;
                    _context.Products.Update(productUpdated);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    UpdateProductStatus(ProductStatus.Unnvailable, productID, out productUpdated);
                    return false;
                }
            }
            return false;
        }
        private bool UpdateProductStatus(ProductStatus statusToChange, long productID, out Product productUpdated)
        {
            productUpdated = null;
            Product productFound = GetProduct(productID);
            if (productFound == null) return false;
            if (statusToChange.Equals(productFound.State)) return false;
            productFound.State = statusToChange;
            _context.Products.Update(productFound);
            _context.SaveChanges();
            productUpdated = productFound;
            return true;


        }
        private bool ValidateProductData(Product productData)
        {
            if (string.IsNullOrWhiteSpace(productData.Title)) return false;
            if (string.IsNullOrWhiteSpace(productData.ShortDescription)) return false;
            if (string.IsNullOrWhiteSpace(productData.LongDescription)) return false;
            if (productData.Date == null) return false;
            if (productData.Price < 0) return false;
            return true;
        }

        public bool BuyProductsOfLoggedUser(string username)
        {
            try
            {
                var productsOfUser = _context.Users.First(u => u.UserName.Equals(username)).ProductsAdded;
                if (productsOfUser != null)
                {
                    productsOfUser.ForEach(p => BuyProduct(p));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BuyProductsOfGuest(List<long> productIdsToBuy)
        {
            try
            {
                foreach (var prodId in productIdsToBuy)
                {
                    BuyProduct(GetProduct(prodId));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Product> GetProductsOfGuestByIds(List<long> productIds)
        {
            List<Product> productsFound = new List<Product>();
            foreach (var productId in productIds)
            {
                var productfound = GetProduct(productId);
                if (productfound != null)
                {
                    if (productfound.State == ProductStatus.Unnvailable)
                    {
                        productsFound.Add(GetProduct(productId));
                    }
                }
                
            }
            return productsFound;
        }
    }
}
