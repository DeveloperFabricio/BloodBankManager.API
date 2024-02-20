using BloodBankManager.Application.Commands.CreateDonation;
using BloodBankManager.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Validators
{
    public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationCommandValidator()
        {

            RuleFor(q => q.QuantityMl)
                .GreaterThanOrEqualTo(420)
                .LessThanOrEqualTo(470);

            RuleFor(q => q.QuantityMl)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe a quantidade em mililitros que foram doados!");


            RuleFor(q => q.DonorId)
                .NotEmpty()
                .NotNull()
                .WithMessage("É preciso informar um doador para concluir o registro da doação!");

            RuleFor(d => d.DonationDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe uma data de doação!");
        }
    }
}
