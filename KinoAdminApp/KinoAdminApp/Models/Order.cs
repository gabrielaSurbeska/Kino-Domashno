using System;
using System.Collections.Generic;

namespace KinoAdminApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId  { get; set; }
        public KinoUser User { get; set; }
        public ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
