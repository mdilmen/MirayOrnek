using Microsoft.EntityFrameworkCore;
using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data
{
    public class MirayDbContext : DbContext
    {
        public MirayDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            base.OnModelCreating(bldr); // Do the Default
            bldr.Entity<Product>().HasData(
                                      new Product
                                      {
                                          Id = 1,
                                          Name = "Tasarım Çiçek",
                                          Price = 90,

                                      },
                                      new Product
                                      {
                                          Id = 2,
                                          Name = "Doğum Günü Çiçekleri",
                                          Price = 79,

                                      },
                                      new Product
                                      {
                                          Id = 3,
                                          Name = "Çiçek Buketleri",
                                          Price = 94,

                                      },
                                      new Product
                                      {
                                          Id = 4,
                                          Name = "Lilyum & Zambak",
                                          Price = 108,

                                      });

        }
    }
}

