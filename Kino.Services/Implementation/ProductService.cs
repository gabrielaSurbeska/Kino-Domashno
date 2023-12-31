﻿using Kino.Domain.DomainModels;
using Kino.Domain.DTO;
using Kino.Repository.Implementation;
using Kino.Repository.Interface;
using Kino.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kino.Services.Implementation
{
    
    public class ProductService:IProductService
    {
        private readonly IRepository<Karta> _productRepository;
        private readonly IRepository<KartaInShoppingCart> _productInShoppingCartReository;
        private readonly IUserReopsitory _userReopsitory;

        public ProductService(IRepository<Karta> productRepository, IUserReopsitory userRepository, IRepository<KartaInShoppingCart> productInShoppingCartRepository)
        {
            _productRepository = productRepository;
            _userReopsitory = userRepository;
            _productInShoppingCartReository = productInShoppingCartRepository;
           
        }

        public bool AddToShoppingCart(AddToShoppingCardDTO item, string userID)
        {
           var user = _userReopsitory.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.ProductId != null && userShoppingCard != null)
            {
                var product = GetDetailsForProduct(item.ProductId);

                if (product != null)
                {
                    KartaInShoppingCart itemToAdd = new KartaInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        ProductId = product.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.ProductInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.ProductId == itemToAdd.ProductId).FirstOrDefault();

                    if (existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        _productInShoppingCartReository.Update(existing);

                    }
                    else
                    {
                        _productInShoppingCartReository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;        }

        public void CreateNewProduct(Karta product)
        {
            _productRepository.Insert(product);
        }

        public void DeleteProduct(Guid? id)
        {
            var product = GetDetailsForProduct(id);
            _productRepository.Delete(product);
        }

        public List<Karta> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Karta GetDetailsForProduct(Guid? id)
        {
           return _productRepository.Get(id);
        }

        public AddToShoppingCardDTO GetShoppingCardInfo(Guid? id)
        {
            var product = GetDetailsForProduct(id);
            AddToShoppingCardDTO model = new AddToShoppingCardDTO
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };
            return model;
        }
        public void UpdateExisingProduct(Karta product)
        {
            _productRepository.Update(product);
        }
    }
}
