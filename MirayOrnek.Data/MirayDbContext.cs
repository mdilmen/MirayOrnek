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
        public virtual DbSet<Basket> Baskets { get; set; }

        public virtual DbSet<BasketItem> BasketItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            base.OnModelCreating(bldr);

            bldr.Entity<Basket>(entity =>
            {
                entity.ToTable("Baskets");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();
            });

            bldr.Entity<BasketItem>(entity =>
            {
                entity.ToTable("BasketItems");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.BasketId)
                    .HasConstraintName("constraint_name");
            });

            bldr.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(10,2)");
                entity.HasData(
                                      new Product
                                      {
                                          Id = 1,
                                          Name = "Tasarım Çiçek",
                                          Price = 90,
                                          IsActive=true,
                                          CreateDate=DateTime.Now

                                      },
                                      new Product
                                      {
                                          Id = 2,
                                          Name = "Doğum Günü Çiçekleri",
                                          Price = 79,
                                          IsActive = true,
                                          CreateDate = DateTime.Now
                                      },
                                      new Product
                                      {
                                          Id = 3,
                                          Name = "Çiçek Buketleri",
                                          Price = 94,
                                          IsActive = true,
                                          CreateDate = DateTime.Now
                                      },
                                      new Product
                                      {
                                          Id = 4,
                                          Name = "Lilyum & Zambak",
                                          Price = 108,
                                          IsActive = true,
                                          CreateDate = DateTime.Now
                                      });

            });
        }
    }
}

