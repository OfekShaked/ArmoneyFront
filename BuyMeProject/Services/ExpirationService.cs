using Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BuyMeProject.Services
{
    public class ExpirationService
    {
        IServiceScopeFactory _serviceScopeFactory;
        Timer expirationTimer;
        readonly TimeSpan checkForExpiredItemsPeriod = new TimeSpan(0, 10, 0);
        public ExpirationService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            expirationTimer = new Timer();
            expirationTimer.Interval = checkForExpiredItemsPeriod.TotalMilliseconds;
            expirationTimer.Elapsed += RemoveExpiredBasketItems;
            expirationTimer.AutoReset = true;
            expirationTimer.Start();
        }
        private void RemoveExpiredBasketItems(object sender, ElapsedEventArgs e)
        {
            var _context = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            var expiredProducts = _context.Products.Where(p => p.BasketExpirationDate < DateTime.Now && p.State != ProductStatus.Sold).ToList();
                expiredProducts.ForEach(
                  (p) =>
                {
                    p.State = ProductStatus.ForSale;
                    p.UserId = null;
                    p.BasketExpirationDate = null;
                    _context.Products.Update(p);
                });
            _context.SaveChanges();

        }
    }
}
