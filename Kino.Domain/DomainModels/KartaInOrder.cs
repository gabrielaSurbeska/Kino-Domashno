using System;

namespace Kino.Domain.DomainModels
{
    public class KartaInOrder:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Karta OrderedProduct { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
        public int Quantity { get; set; }
    }
}
