using System;

namespace Kino.Domain.DomainModels
{
    public class KartaInShoppingCart:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Karta Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
