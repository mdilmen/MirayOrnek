using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace MirayOrnek.Data.Entitites
{
    public class BasketItem : BaseEntity
    {
        public int? BasketId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
