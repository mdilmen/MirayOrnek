using Microsoft.AspNetCore.Mvc;
using MirayOrnek.Data;
using MirayOrnek.Data.Entitites;
using MirayOrnek.Logger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MirayOrnek.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductForecastController : ControllerBase
    {
        private readonly ILoggers _logger;
        private readonly IRepository _repository;

        public ProductForecastController(ILoggers logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet(Name = "GetProductForecast")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogWrite("Service called! {DateTime.Now.ToShortTimeString()}");
           
            var result = await _repository.GetAllProducts();
            return result;
        }
        
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            _logger.LogWrite("GetProductById called!");
            var result = await _repository.GetProductById(id);
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Put([FromBody] Product product)
        {
            _logger.LogWrite("UpdateProduct called!");
            var result = await _repository.UpdateProduct(product);
            return result;
        }
       
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var basket = await _repository.GetProductById(id);
            if (basket == null)
            {
                _logger.LogWrite("Couldn't find id : " + id);
                return BadRequest();
            }
            _logger.LogWrite("DeleteProduct called! ");
            await _repository.DeleteProduct(id);
            return Accepted();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            _logger.LogWrite("CreateProduct called!");
            var result = await _repository.CreateProduct(product);
            return result;
        }

    }
}
