using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetDonationById
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, DonationViewModel>
    {
        private readonly IDonationRepository _donationRepository;
        public GetDonationByIdQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<DonationViewModel> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetDonationById(request.Id);

            var donationViewModel = donation.ConvertDonationViewModelById();

            return donationViewModel;
        }
    }
}
