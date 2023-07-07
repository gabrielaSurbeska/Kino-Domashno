using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Kino.Domain.DomainModels
{
    public class Karta:BaseEntity
    {
        [Required]
        [Display(Name = "Name of the Movie")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Poster")]
        public string ProductImage { get; set; }
        [Required]
        [Display(Name = "Ticket Price")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Raiting")]
        public int Rating { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime data { get; set; }
        public virtual ICollection<KartaInShoppingCart> ProductInShoppingCarts { get; set; }
        public IEnumerable<KartaInOrder> ProductInOrders { get; set; }
    }
}
