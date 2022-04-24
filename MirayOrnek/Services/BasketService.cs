using Microsoft.Extensions.Logging;
using MirayOrnek.Data.Repositories.Interfaces;
using MirayOrnek.Dtos;
using MirayOrnek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MirayOrnek.Data.Entitites;
using AutoMapper;
using FluentValidation;

namespace MirayOrnek.Services
{
    public class BasketService : IBasketService
    {
        private readonly ILogger<BasketService> _logger;
        private readonly IValidator<BasketCreateDto> _basketValidator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;


        public BasketService(ILogger<BasketService> logger, IValidator<BasketCreateDto> basketValidator, IMapper mapper, IProductRepository productRepository, IBasketRepository basketRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _basketValidator = basketValidator;
            _productRepository = productRepository;
            _basketRepository = basketRepository;
        }

        public async Task<Response<IEnumerable<BasketDto>>> GetAllBaskets()
        {
            try
            {
                var entitites = await _basketRepository.GetAllBaskets();

                var basketDtos = _mapper.Map<List<BasketDto>>(entitites);

                return Response<IEnumerable<BasketDto>>.Success(basketDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<IEnumerable<BasketDto>>.Fail(ex.Message);
            }

        }

        public async Task<Response<BasketDto>> GetBasket(int id)
        {
            try
            {
                var entity = await _basketRepository.GetBasket(id);

                if (entity == null)
                {
                    return Response<BasketDto>.Fail("Not Found");
                }

                var basketDto = _mapper.Map<BasketDto>(entity);

                return Response<BasketDto>.Success(basketDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<BasketDto>.Fail(ex.Message);
            }
        }

        public async Task<Response<bool>> SaveBasket(BasketCreateDto basketCreateDto)
        {
            try
            {
                var validationResult = await this.ValidateBasket(basketCreateDto);

                if (!validationResult.IsSuccessful)
                {
                    return validationResult;
                }

                var basketEntity = new Basket();
                basketEntity.BasketItemCount = basketCreateDto.BasketItems.Count();

                await _basketRepository.CreateBasket(basketEntity);

                await SaveBasketItems(basketEntity.Id, basketCreateDto.BasketItems);

                return Response<bool>.Success(true);

            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error.", ex);
                return Response<bool>.Fail(ex.Message);
            }
        }

        private async Task<Response<bool>> ValidateBasket(BasketCreateDto request)
        {
            var validationResult = await _basketValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                string errorMessage = validationResult.Errors.First().ErrorMessage;
                return Response<bool>.Fail(errorMessage);
            }

            foreach (var basketItem in request.BasketItems)
            {
                bool existProduct = await _productRepository.ExistProduct(basketItem.ProductId);

                if (!existProduct)
                {
                    return Response<bool>.Fail("Invalid request. Product not found.");
                }
            }

            return Response<bool>.Success(true);
        }

        private async Task<bool> SaveBasketItems(int basketId, List<BasketItemCreateDto> basketItemCreateDto)
        {
            List<BasketItem> basketItemEntities = new List<BasketItem>();

            foreach (var basketItemDto in basketItemCreateDto)
            {
                var productEntity = await _productRepository.GetProduct(basketItemDto.ProductId);

                BasketItem basketItemEntity = new BasketItem
                {
                    BasketId = basketId,
                    CreateDate = DateTime.Now,
                    ProductId = productEntity.Id,
                    ProductName = productEntity.Name,
                    ProductPrice = productEntity.Price,
                    Quantity = basketItemDto.Quantity,
                    TotalPrice = basketItemDto.Quantity * productEntity.Price,
                };

                basketItemEntities.Add(basketItemEntity);
            }

            bool isSuccessfuly = await _basketRepository.AddBasketItems(basketItemEntities);

            return isSuccessfuly;
        }
    }
}
