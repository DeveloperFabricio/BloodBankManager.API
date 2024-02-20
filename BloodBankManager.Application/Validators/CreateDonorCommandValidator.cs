using BloodBankManager.Application.Commands.CreateDonor;
using BloodBankManager.Core.Repositories;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BloodBankManager.Application.Validators
{
    public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandValidator(IDonorRepository donorRepository)
        {

            _donorRepository = donorRepository; 


            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("O Endereço de e-mail precisa ser válido!");

            RuleFor(e => e.Email)
                .Must(CheckEmail)
                .WithMessage("O email inserido já está cadastrado");

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo email não pode ser vazio ou nulo");

            RuleFor(n => n.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("O campo nome não pode ser vazio ou nulo, e precisa ter no mínimo 3 caracteres");

            RuleFor(a => a.Address.ZipCode)
                .Must(ValidZipCodeOnlyNumbers)
                .WithMessage("Formato do CEP aceito é: XXXXXXXX, com 8 dígitos");
        }

        private bool CheckEmail(string email)
        {
            var emailExist = _donorRepository.CheckEmailNoExists(email).Result;

            if (emailExist)
            {
                return false;
            }
            return true;
        }

        private bool ValidZipCodeOnlyNumbers(string zipCode)
        {
            var regexWithSeparators = new Regex(@"^(?!.*[^\d]).{8}$");

            return regexWithSeparators.IsMatch(zipCode);
        }
    }
}
