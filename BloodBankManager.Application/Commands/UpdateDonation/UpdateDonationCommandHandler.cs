using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.UpdateDonation
{
    public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, Unit>
    {
        private readonly IDonationRepository _donationRepository;
        public UpdateDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<Unit> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetDonationById(request.Id);

            donation.Update(request.DonorId, request.QuantityMl);

            await _donationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
