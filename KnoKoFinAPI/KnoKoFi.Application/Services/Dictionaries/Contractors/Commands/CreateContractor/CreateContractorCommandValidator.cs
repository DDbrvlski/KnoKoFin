using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandValidator : AbstractValidator<CreateContractorCommand>  
    {
        public CreateContractorCommandValidator()
        {
            // Walidacja ContractorType - musi być poprawnym typem z enumeracji
            RuleFor(x => x.ContractorType)
                .IsInEnum()
                .WithMessage("Typ kontrahenta musi być jednym z: Internal, External.");

            // Name - wymagane pole
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nazwa kontrahenta jest wymagana.")
                .MaximumLength(100)
                .WithMessage("Nazwa kontrahenta nie może mieć więcej niż 100 znaków.");

            // FirstName - opcjonalne, ale maksymalna długość
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithMessage("Imię nie może mieć więcej niż 50 znaków.");

            // LastName - opcjonalne, ale maksymalna długość
            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Nazwisko nie może mieć więcej niż 50 znaków.");

            // Description - opcjonalne, maksymalna długość
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Opis nie może mieć więcej niż 500 znaków.");

            // Nip - opcjonalne, ale musi być poprawnym numerem NIP
            RuleFor(x => x.Nip)
                .Matches(@"^\d{10}$")
                .When(x => !string.IsNullOrWhiteSpace(x.Nip))
                .WithMessage("NIP musi składać się z dokładnie 10 cyfr.");

            // Email - opcjonalne, ale musi być poprawnym adresem e-mail
            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Podano nieprawidłowy adres e-mail.");

            // PhoneNumber - opcjonalne, ale musi być poprawnym numerem telefonu
            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Numer telefonu musi zawierać od 7 do 15 cyfr i może zawierać spacje lub myślniki.");

            // BankAccountNumber - wymagane pole, sprawdzenie długości (np. IBAN)
            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .WithMessage("Numer konta bankowego jest wymagany.")
                .Matches(@"^[A-Z0-9]{15,34}$")
                .WithMessage("Numer konta bankowego musi być w formacie IBAN (15-34 znaków alfanumerycznych).");

            // BankName - wymagane pole
            RuleFor(x => x.BankName)
                .NotEmpty()
                .WithMessage("Nazwa banku jest wymagana.")
                .MaximumLength(100)
                .WithMessage("Nazwa banku nie może mieć więcej niż 100 znaków.");

            // Fax - opcjonalne, ale maksymalna długość
            RuleFor(x => x.Fax)
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.Fax))
                .WithMessage("Fax nie może mieć więcej niż 20 znaków.");

            // Swift - opcjonalne, sprawdzenie formatu SWIFT/BIC
            RuleFor(x => x.Swift)
                .Matches(@"^[A-Z]{6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3})?$")
                .When(x => !string.IsNullOrWhiteSpace(x.Swift))
                .WithMessage("Kod SWIFT/BIC jest nieprawidłowy.");
        }
    }
}
