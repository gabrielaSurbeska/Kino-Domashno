using Kino.Domain.Identity;
using System.Collections.Generic;

namespace Kino.Domain.DomainModels
{
    public class Order: BaseEntity
    {
        public string UserId { get; set; }
        public KinoUser User { get; set; }
        public IEnumerable<KartaInOrder> ProductInOrders { get; set; }
    }
}
