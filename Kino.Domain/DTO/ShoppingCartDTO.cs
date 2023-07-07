using Kino.Domain.DomainModels;
using System.Collections.Generic;

namespace Kino.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<KartaInShoppingCart> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
