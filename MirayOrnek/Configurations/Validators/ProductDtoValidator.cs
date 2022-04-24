using FluentValidation;
using MirayOrnek.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirayOrnek.Configurations.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().NotEqual("string").WithMessage("Invalid product.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Invalid price.");

        }
    }
}
