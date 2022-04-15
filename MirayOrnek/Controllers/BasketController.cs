using Microsoft.AspNetCore.Mvc;
using MirayOrnek.Data;
using MirayOrnek.Data.Entitites;
using MirayOrnek.Helper;
using MirayOrnek.Logger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MirayOrnek.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILoggers _logger;
        private readonly IBasketRepository _repository;

        public BasketController(ILoggers logger, IBasketRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}", Name = "GetBasket")]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> GetBasket(int id)
        {
            _logger.LogWrite("GetBasketById called!");
            var basket = await _repository.GetBasketById(id);
            return Ok(basket);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> UpdateBasket([FromBody] Basket basket)
        {
            _logger.LogWrite("UpdateBasket called!");
            CalculateHelper calculateHelper = new CalculateHelper();
            basket.Quantity = calculateHelper.BuyMoreThanTwoGetOneFree(basket.Quantity);

            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{id}", Name = "DeleteBasket")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var basket = await _repository.GetBasketById(id);
            if (basket == null)
            {
                _logger.LogWrite("Couldn't find id : " + id);
                return BadRequest();
            }
            _logger.LogWrite("DeleteBasket called!");
            await _repository.DeleteBasket(id);
            return Accepted();
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> Post([FromBody] Basket basket)
        {
            _logger.LogWrite("CreateBasket called!");
            var result = await _repository.CreateBasket(basket);
            return result;
        }

    }
}
