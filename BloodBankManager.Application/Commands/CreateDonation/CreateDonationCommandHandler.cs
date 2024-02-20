using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using BloodBankManager.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStorageService _storageService;
        private readonly IDonorService _donorService;
        private readonly IDonorRepository _donorRepository;
        public CreateDonationCommandHandler(IDonationRepository donationRepository, IBloodStorageService storageService, IDonorService donorService, IDonorRepository donorRepository = null)
        {
            _donationRepository = donationRepository;
            _storageService = storageService;
            _donorService = donorService;
            _donorRepository = donorRepository;
        }
        public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorWithDonationsById(request.DonorId);

            var donation = new Donation(request.DonorId,
                                        request.DonationDate,
                                        request.QuantityMl);

            await _donorService.CheckDonorIsValid(donor);

            await _donationRepository.CreateDonation(donation);

            await _storageService.AddBloodStorage(donation.DonorId, donation.QuantityMl);  

            return donation.Id;
        }


    }
}
