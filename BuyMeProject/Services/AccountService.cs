using Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuyMeProject.Services
{
    public class AccountService : IAccountService
    {
        DataContext _context;
        public decimal LoggedDiscountAmount => (decimal)0.9;

        public AccountService(DataContext context)
        {
            _context = context;
        }
        public bool ConfirmLogin(string username, string password)
        {
            try
            {
                var userData = _context.Users.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password));
                if (userData != null) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Register(User newUserData)
        {
            try
            {
                if (ValidateUserData(newUserData,false))
                {
                    _context.Users.Add(newUserData);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private bool ValidateUserData(User userData, bool isForUpdate)
        {
            try
            {
                if (!isForUpdate)
                {
                    if (_context.Users.FirstOrDefault(u => u.UserName.Equals(userData.UserName)) != null) return false;
                }
                if (userData.FirstName == null) return false;
                if (IsEmailValid(userData.Email) == false) return false;
                if (userData.LastName == null) return false;
                if (userData.BirthDate == null) return false;
                if (userData.UserName == null) return false;
                if (userData.Password == null) return false;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private bool IsEmailValid(string emailAdress)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            return regex.Match(emailAdress).Success;
        }

        public User GetUser(string username)
        {
            try
            {
                User userFound = _context.Users.AsNoTracking().FirstOrDefault(u => u.UserName.Equals(username));
                if (userFound != null)
                {
                    userFound.Password = null;
                }
                return userFound;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public long? GetUserId(string username)
        {
            var user = GetUser(username);
            if (user != null)
                return user.Id;
            return null;
        }
        public bool UpdateUser(User updatedUser)
        {
            try
            {
                User userFound = _context.Users.FirstOrDefault(u => u.UserName.Equals(updatedUser.UserName));
                if (userFound != null)
                {
                    updatedUser.Id = userFound.Id;
                    if (String.IsNullOrWhiteSpace(updatedUser.Password)) updatedUser.Password = userFound.Password;
                }
                if (ValidateUserData(updatedUser,true))
                {
                    _context.Entry(userFound).CurrentValues.SetValues(updatedUser);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool IsUsernameAvailable(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(username));
            return (user == null);
        }

        public List<Product> GetProductsByUser(string username)
        {
            var userId = GetUserId(username);
            var products = _context.Products.Where(p => p.UserId.Equals(userId) && p.State.Equals(ProductStatus.Unnvailable)).ToList();
            if (products != null)
            {
                return products;
            }
            return new List<Product>();
        }
        public decimal GetShoppingCartSum(List<Product> cartProducts)
        {
            decimal sumValue = 0;
            foreach (var item in cartProducts)
            {
                sumValue += item.Price;
            }
            return sumValue;

        }
    }
}
