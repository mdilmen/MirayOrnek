using FluentValidation;
using MirayOrnek.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Configurations.Validators
{
    public class BasketSaveDtoValidator : AbstractValidator<BasketCreateDto>
    {
        public BasketSaveDtoValidator()
        {
            RuleForEach(x => x.BasketItems).NotNull().WithMessage("Basket item is required.");

            RuleForEach(x => x.BasketItems).ChildRules(basketItem =>
            {
                basketItem.RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Invalid product.");
                basketItem.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must have a total of more than 0.");
            });
        }
    }
}
