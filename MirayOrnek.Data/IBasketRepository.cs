using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data
{
    public interface IBasketRepository
    {        
        Task<Basket> GetBasketById(int id);
        Task<Basket> CreateBasket(Basket product);
        Task<Basket> UpdateBasket(Basket product);
        Task DeleteBasket(int id);
    }
}
