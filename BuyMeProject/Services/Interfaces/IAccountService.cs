using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Services
{
    public interface IAccountService
    {
        decimal LoggedDiscountAmount { get; }
        bool ConfirmLogin(string username, string password);
        bool Register(User newUserData);
        User GetUser(string username);
        bool UpdateUser(User updatedUser);
        bool IsUsernameAvailable(string username);
        long? GetUserId(string username);
        List<Product> GetProductsByUser(string username);
        decimal GetShoppingCartSum(List<Product> cartProducts);
    }
}
