using Kino.Domain.DomainModels;
using System.Collections.Generic;

namespace Kino.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
