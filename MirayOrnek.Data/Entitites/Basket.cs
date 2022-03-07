using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Entitites
{
    public class Basket
    {
        public Basket()
        {
            this.Products = new List<Product>();
        }
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public int Quantity { get; set; }
    }
}
