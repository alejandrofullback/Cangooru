using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Services.DTO;

namespace Cangooru.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrdersByUserId(Guid userId);
    }
}
