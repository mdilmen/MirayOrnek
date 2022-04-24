using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MirayOrnek.Dtos;
using MirayOrnek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirayOrnek.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(ILogger<BasketController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpGet(Name = "GetAllBaskets")]
        public async Task<Response<IEnumerable<BasketDto>>> Get()
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _basketService.GetAllBaskets();
            return result;
        }

        [HttpGet("{id}", Name = "GetBasket")]
        public async Task<Response<BasketDto>> GetById(int id)
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _basketService.GetBasket(id);
            return result;
        }

        [HttpPost(Name = "SaveBasket")]
        public async Task<Response<bool>> Save(BasketCreateDto basketCreateDto)
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _basketService.SaveBasket(basketCreateDto);
            return result;
        }
    }
}
