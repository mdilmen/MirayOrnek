using MirayOrnek.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MirayOrnek.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(int id);
        Task<Response<IEnumerable<BasketDto>>> GetAllBaskets();
        Task<Response<bool>> SaveBasket(BasketCreateDto basketCreateDto);
    }
}
