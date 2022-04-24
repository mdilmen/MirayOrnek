using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Dtos
{
    public class BasketCreateDto
    {
        public virtual List<BasketItemCreateDto> BasketItems { get; set; }
    }
}
