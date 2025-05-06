using FluentValidation;
using KnoKoFin.Application.Validators;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
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
