using AutoMapper;
using MirayOrnek.Data.Entitites;
using MirayOrnek.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Configurations.Mapper
{
    public class MirayOrnekMapperProfile : Profile,
        ITypeConverter<Product, ProductDto>,
        ITypeConverter<ProductDto, Product>,
        ITypeConverter<List<Product>, List<ProductDto>>,
        ITypeConverter<List<ProductDto>, List<Product>>,
        ITypeConverter<Basket, BasketDto>,
        ITypeConverter<List<Basket>, List<BasketDto>>
    {
        public MirayOrnekMapperProfile()
        {
            this.CreateMap<Product, ProductDto>().ConvertUsing(this);
            this.CreateMap<ProductDto, Product>().ConvertUsing(this);
            this.CreateMap<List<Product>, List<ProductDto>>().ConvertUsing(this);
            this.CreateMap<List<ProductDto>, List<Product>>().ConvertUsing(this);
            this.CreateMap<Basket, BasketDto>().ConvertUsing(this);
            this.CreateMap<List<Basket>, List<BasketDto>>().ConvertUsing(this);
        }

        public ProductDto Convert(Product source, ProductDto destination, ResolutionContext context)
        {
            destination = new ProductDto
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price
            };

            return destination;
        }

        public List<ProductDto> Convert(List<Product> source, List<ProductDto> destination, ResolutionContext context)
        {
            destination = source.Select(e => new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price
            }).ToList();

            return destination;
        }

        public Product Convert(ProductDto source, Product destination, ResolutionContext context)
        {
            destination = new Product
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price
            };

            return destination;
        }

        public List<Product> Convert(List<ProductDto> source, List<Product> destination, ResolutionContext context)
        {
            destination = source.Select(e => new Product
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price
            }).ToList();

            return destination;
        }

        public BasketDto Convert(Basket source, BasketDto destination, ResolutionContext context)
        {
            destination = new BasketDto
            {
                Id=source.Id,
                BasketItemCount = source.BasketItemCount,
                CreateDate = source.CreateDate,
                LastModifiedDate = source.LastModifiedDate,
                TotalPrice = source.BasketItems.Sum(e => e.TotalPrice),
                BasketItems = source.BasketItems.Select(e => new BasketItemDto
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    ProductPrice = e.ProductPrice,
                    TotalPrice = e.TotalPrice,
                    Quantity = e.Quantity

                }).ToList()
            };

            return destination;
        }

        public List<BasketDto> Convert(List<Basket> source, List<BasketDto> destination, ResolutionContext context)
        {
            destination = source.Select(e => new BasketDto
            {
                Id= e.Id,
                BasketItemCount = e.BasketItemCount,
                CreateDate = e.CreateDate,
                LastModifiedDate = e.LastModifiedDate,
                TotalPrice = e.BasketItems.Sum(e => e.TotalPrice),
                BasketItems = e.BasketItems.Select(x => new BasketItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    TotalPrice = x.TotalPrice,
                    Quantity = x.Quantity

                }).ToList()
            }).ToList();

            return destination;
        }
    }
}
