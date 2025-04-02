using FluentValidation;
using KnoKoFin.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            // ID
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID jest wymagane")
                .GreaterThan(0).WithMessage("ID jest niepoprawne");

            // Ulica
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Ulica jest wymagana")
                .MaximumLength(100).WithMessage("Maksymalna długość ulicy to 100 znaków");

            // Miasto
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Miasto jest wymagane")
                .Matches("^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ ]+$").WithMessage("Nieprawidłowa nazwa miasta");

            // Kod pocztowy
            RuleFor(x => x.PostCode)
                .NotEmpty()
               .Must((address, code) => PostalCodeValidator.IsValidPostalCode(code, address.Country))
               .WithMessage("Kod pocztowy nie pasuje do kraju");

            // Kraj (np. z enum)
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Kraj jest wymagany")
                .Must(CountryValidator.IsValidCountry).WithMessage("Nieprawidłowy kraj");
        }
    }
}
