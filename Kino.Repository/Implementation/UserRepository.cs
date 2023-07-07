using Kino.Domain.Identity;
using Kino.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kino.Repository.Implementation
{
    public class UserRepository : IUserReopsitory
    {
        private readonly ApplicationDbContext context;
        private DbSet<KinoUser> entities;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities =  context.Set<KinoUser>();
        }
        public void Delete(KinoUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            entities.Remove(user);
            context.SaveChanges();
        }

        public KinoUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.ProductInShoppingCarts")
               .Include("UserCart.ProductInShoppingCarts.Product")
               .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<KinoUser> GetAll()
        {
           return entities.AsEnumerable();
        }

        public void Insert(KinoUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            entities.Add(user);
            context.SaveChanges();
        }

        public void Update(KinoUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            entities.Update(user);
            context.SaveChanges();
        }
    }
}
