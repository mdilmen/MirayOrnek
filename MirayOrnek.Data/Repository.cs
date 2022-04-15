using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data
{
    public class Repository : IRepository
    {
        private readonly MirayDbContext _dbContext;

        public Repository(MirayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _dbContext.Products.ToListAsync();
            return result;
        }
        public async Task<Product> GetProductById(int id)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
       
        public async Task DeleteProduct(int id)
        {
            var deleteProduct = await GetProductById(id);
           _dbContext.Products.Remove(deleteProduct);
            await _dbContext.SaveChangesAsync();
        }
    }
}
