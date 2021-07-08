
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BuyMeProject.Services
{
    public interface IProductService
    {
        bool AddNewProduct(Product newProduct);
        bool AddProductToBasket(long productID,long? userId,List<long> guestProducts=null);
        bool RemoveProductFromBasket(long productID);
        bool BuyProductsOfLoggedUser(string username);
        bool BuyProductsOfGuest(List<long> productIdsToBuy);
        Product GetProduct(long productID);
        List<Product> GetProductsOfGuestByIds(List<long> productIds);
        List<Product> GetAllAvailableProducts(string orderByProperty = null);

    }
}
