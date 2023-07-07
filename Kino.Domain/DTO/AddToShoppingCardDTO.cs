using Kino.Domain.DomainModels;
using System;

namespace Kino.Domain.DTO
{
    public class AddToShoppingCardDTO
    {
        public Karta SelectedProduct { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
