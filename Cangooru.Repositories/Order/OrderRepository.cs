using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Repositories.Interfaces;

namespace Cangooru.Repositories.Order
{
    public class OrderRepository : IDisposable, IOrderRepository
    {
        CangooruEntities _entities;
        public OrderRepository()
        {
            _entities = new CangooruEntities();
        }

        /// <summary>
        /// Get the list of orders of an User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<cangooru_Order> GetOrdersByUser(Guid userId)
        {
            return _entities.cangooru_Order.Where(order => order.OwnerId == userId);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}
