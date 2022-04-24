using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data.Entitites;
using MirayOrnek.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly MirayDbContext _dbContext;

        public BasketRepository(MirayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddBasketItems(List<BasketItem> entities)
        {
            entities.ForEach(entity =>
            {
                _dbContext.BasketItems.Add(entity);
            });

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateBasket(Basket entity)
        {
            entity.CreateDate = DateTime.Now;
            _dbContext.Baskets.Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Basket>> GetAllBaskets()
        {
            var entities = await _dbContext.Baskets
                    .Include(basket => basket.BasketItems)
                    .ToListAsync();

            return entities;
        }

        public async Task<Basket> GetBasket(int id)
        {
            var entity = await _dbContext.Baskets.Where(e => e.Id == id)
                    .Include(basket => basket.BasketItems)
                    .FirstOrDefaultAsync();

            return entity;
        }
    }
}
