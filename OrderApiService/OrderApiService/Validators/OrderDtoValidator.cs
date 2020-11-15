using FluentValidation;
using OrderApiService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApiService.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.CustomerFullName)
                .NotNull()
                .WithMessage("The customer name must not be null");

            RuleFor(x => x.CustomerFullName)
                .MinimumLength(2)
                .WithMessage("The customer name must be at least 2 character long");
        }
    }
}
