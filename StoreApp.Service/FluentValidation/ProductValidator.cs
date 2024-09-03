using FluentValidation;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.Information)
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(3000);

            RuleFor(x => x.Price)
                .NotEmpty();

        }
    }
}
