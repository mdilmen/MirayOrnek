using MirayOrnek.Data.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(int id);

        Task<List<Basket>> GetAllBaskets();

        Task<bool> CreateBasket(Basket entity);

        Task<bool> AddBasketItems(List<BasketItem> entities);
    }
}
