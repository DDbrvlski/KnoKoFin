using FluentValidation;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandValidator : AbstractValidator<CreateContractorCommand>
    {
        public CreateContractorCommandValidator()
        {
            RuleFor(x => x.ContractorType)
                .IsInEnum()
                .WithMessage("Typ kontrahenta musi być jednym z: Internal, External.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nazwa kontrahenta jest wymagana.")
                .MaximumLength(100)
                .WithMessage("Nazwa kontrahenta nie może mieć więcej niż 100 znaków.");

            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithMessage("Imię nie może mieć więcej niż 50 znaków.");

            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Nazwisko nie może mieć więcej niż 50 znaków.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Opis nie może mieć więcej niż 500 znaków.");

            RuleFor(x => x.Nip)
                .Matches(@"^\d{10}$")
                .When(x => !string.IsNullOrWhiteSpace(x.Nip))
                .WithMessage("NIP musi składać się z dokładnie 10 cyfr.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Podano nieprawidłowy adres e-mail.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Numer telefonu musi zawierać od 7 do 15 cyfr i może zawierać spacje lub myślniki.");

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .WithMessage("Numer konta bankowego jest wymagany.")
                .Matches(@"^[A-Z0-9]{15,34}$")
                .WithMessage("Numer konta bankowego musi być w formacie IBAN (15-34 znaków alfanumerycznych).");

            RuleFor(x => x.BankName)
                .NotEmpty()
                .WithMessage("Nazwa banku jest wymagana.")
                .MaximumLength(100)
                .WithMessage("Nazwa banku nie może mieć więcej niż 100 znaków.");

            RuleFor(x => x.Fax)
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.Fax))
                .WithMessage("Fax nie może mieć więcej niż 20 znaków.");

            RuleFor(x => x.Swift)
                .Matches(@"^[A-Z]{6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3})?$")
                .When(x => !string.IsNullOrWhiteSpace(x.Swift))
                .WithMessage("Kod SWIFT/BIC jest nieprawidłowy.");
        }
    }
}
