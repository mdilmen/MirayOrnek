using MirayOrnek.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response<ProductDto>> GetProduct(int id);
        Task<Response<IEnumerable<ProductDto>>> GetAllProducts();
        Task<Response<bool>> SaveProduct(ProductDto product);
    }
}
