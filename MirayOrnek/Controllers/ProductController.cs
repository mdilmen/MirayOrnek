using Microsoft.AspNetCore.Mvc;
using MirayOrnek.Dtos;
using MirayOrnek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MirayOrnek.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<Response<IEnumerable<ProductDto>>> Get()
        {
            _logger.LogWarning($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _productService.GetAllProducts();
            return result;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<Response<ProductDto>> GetById(int id)
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _productService.GetProduct(id);
            return result;
        }

        [HttpPost(Name = "SaveProduct")]
        public async Task<Response<bool>> Save(ProductDto product)
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _productService.SaveProduct(product);
            return result;
        }
    }
}
