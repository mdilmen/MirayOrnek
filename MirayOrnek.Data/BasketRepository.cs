using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly MirayDbContext _dbContext;

        public BasketRepository(MirayDbContext dbContext)
        {
            _dbContext = dbContext;
        }      
        public async Task<Basket> GetBasketById(int id)
        {
            var result = await _dbContext.Baskets.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Basket> CreateBasket(Basket basket)
        {
            await _dbContext.Baskets.AddAsync(basket);
            await _dbContext.SaveChangesAsync();
            return basket;
        }
        public async Task<Basket> UpdateBasket(Basket basket)
        {
            _dbContext.Baskets.Update(basket);
            await _dbContext.SaveChangesAsync();
            return basket;
        }
       
        public async Task DeleteBasket(int id)
        {
            var deleteBasket = await GetBasketById(id);
           _dbContext.Baskets.Remove(deleteBasket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
