using CustomerApiService.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApiService.Validators
{
    public class UpdateCustomerDtoValidator: AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .WithMessage("The first name must be at least 2 characters long");


            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .WithMessage("The last name must be at least 2 characters long");

            RuleFor(x => x.Birthday)
                .InclusiveBetween(DateTime.UtcNow.AddYears(-120), DateTime.UtcNow)
                .WithMessage("The birthday must not be more than 120 years ago and can not be in the future");

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120)
                .WithMessage("The age can be between 0 and 120 years");
        }
    }
}
