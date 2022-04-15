using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Helper
{
    public class CalculateHelper
    {
        public  int BuyMoreThanTwoGetOneFree(int quantity)
        {
            //If you buy two, one item will be calculated as a gift 
            if (quantity > 2)
            {
                quantity--;
            }
            return quantity;
        }
    }
}
