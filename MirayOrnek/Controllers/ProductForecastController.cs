using Microsoft.AspNetCore.Mvc;
using MirayOrnek.Data;
using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductForecastController : ControllerBase
    {
        private readonly ILogger<ProductForecastController> _logger;
        private readonly IRepository _repository;

        public ProductForecastController(ILogger<ProductForecastController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet(Name = "GetProductForecast")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogInformation($"Service called! {DateTime.Now.ToShortTimeString()}");
            var result = await _repository.GetAllProducts();
            return result;
        }
    }
}
