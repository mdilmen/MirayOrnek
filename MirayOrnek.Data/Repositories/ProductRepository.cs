using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data.Entitites;
using MirayOrnek.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MirayDbContext _dbContext;

        public ProductRepository(MirayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateProduct(Product entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.IsActive = true;

            _dbContext.Products.Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistProduct(int id)
        {
            bool exist = await _dbContext.Products.AnyAsync(e => e.IsActive == true & e.Id == id);
            return exist;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var entities = await _dbContext.Products.Where(e => e.IsActive == true).ToListAsync();
            return entities;
        }

        public async Task<Product> GetProduct(int id)
        {
            var entity = await _dbContext.Products.Where(e => e.IsActive == true & e.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<bool> UpdateProduct(Product entity)
        {
            entity.LastModifiedDate = DateTime.Now;

            _dbContext.Entry<Product>(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
