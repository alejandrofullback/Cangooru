using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cangooru.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Get the Orders of an specific user
        /// </summary>
        /// <param name="userId">Id from User</param>
        /// <returns>List of Orders</returns>
        IEnumerable<cangooru_Order> GetOrdersByUser(Guid userId);
    }
}
