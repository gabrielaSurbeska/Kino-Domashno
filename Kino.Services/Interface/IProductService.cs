using Kino.Domain.DomainModels;
using Kino.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Services.Interface
{
    public interface IProductService
    {
        List<Karta> GetAllProducts();
        Karta GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Karta product);
        AddToShoppingCardDTO GetShoppingCardInfo(Guid? id);
        void DeleteProduct(Guid? id);
        bool AddToShoppingCart(AddToShoppingCardDTO item, string userID);
        public void UpdateExisingProduct(Karta product);

    }
}
