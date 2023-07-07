using Kino.Domain.Identity;
using System.Collections.Generic;

namespace Kino.Domain.DomainModels
{
    public class ShoppingCart:BaseEntity
    {
        public string OwnerId { get; set; }
        public KinoUser Owner { get; set; }
        public virtual ICollection<KartaInShoppingCart> ProductInShoppingCarts { get; set; }

    }
}
