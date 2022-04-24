using MirayOrnek.Data.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);

        Task<List<Product>> GetAllProducts();

        Task<bool> CreateProduct(Product entity);

        Task<bool> UpdateProduct(Product entity);

        Task<bool> ExistProduct(int id);

    }
}
