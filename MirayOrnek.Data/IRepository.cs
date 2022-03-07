using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data
{
    public interface IRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}
