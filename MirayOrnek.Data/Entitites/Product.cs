using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Entitites
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
