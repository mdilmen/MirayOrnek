using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Entitites
{
    public class Basket : BaseEntity
    {
        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
        public int BasketItemCount { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
