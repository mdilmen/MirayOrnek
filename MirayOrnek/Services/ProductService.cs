using Microsoft.Extensions.Logging;
using MirayOrnek.Data.Repositories.Interfaces;
using MirayOrnek.Dtos;
using MirayOrnek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MirayOrnek.Data.Entitites;
using AutoMapper;

namespace MirayOrnek.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var productEntites = await _productRepository.GetAllProducts();

                var productDtos = _mapper.Map<List<ProductDto>>(productEntites);

                return Response<IEnumerable<ProductDto>>.Success(productDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<IEnumerable<ProductDto>>.Fail(ex.Message);
            }
        }

        public async Task<Response<ProductDto>> GetProduct(int id)
        {
            try
            {
                var productEntity = await _productRepository.GetProduct(id);

                var productDto = _mapper.Map<ProductDto>(productEntity);

                if (productDto == null)
                {
                    return Response<ProductDto>.Fail("Not Found!");
                }

                return Response<ProductDto>.Success(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<ProductDto>.Fail(ex.Message);
            }
        }

        public async Task<Response<bool>> SaveProduct(ProductDto productDto)
        {
            try
            {
                bool isSuccessfuly = false;

                var productEntity = _mapper.Map<Product>(productDto);

                bool existProduct = await _productRepository.ExistProduct(productEntity.Id);

                if (existProduct)
                {
                    isSuccessfuly = await _productRepository.UpdateProduct(productEntity);
                }
                else
                {
                    isSuccessfuly = await _productRepository.CreateProduct(productEntity);
                }

                return Response<bool>.Success(isSuccessfuly);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<bool>.Fail(false, ex.Message);
            }

        }
    }
}
