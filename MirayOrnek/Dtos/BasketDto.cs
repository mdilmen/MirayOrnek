using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Dtos
{
    public class BasketDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int BasketItemCount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<BasketItemDto> BasketItems { get; set; }
    }
}
