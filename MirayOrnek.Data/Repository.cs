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
    }
}
