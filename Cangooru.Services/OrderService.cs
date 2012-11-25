using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cangooru.Services.Interfaces;
using Cangooru.Repositories.Interfaces;

namespace Cangooru.Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DTO.OrderDTO> GetOrdersByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
