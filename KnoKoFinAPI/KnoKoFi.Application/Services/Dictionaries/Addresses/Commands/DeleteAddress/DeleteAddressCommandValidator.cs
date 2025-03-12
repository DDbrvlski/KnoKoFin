using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator()
        {
            //ID
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID nie może być puste")
                .GreaterThan(0).WithMessage("ID nie jest poprawne");
        }
    }
}
