using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Queries.GetDonationsRelatory
{
    public class GetDonationsRelatoryQueryHandler : IRequestHandler<GetDonationsRelatoryQuery, List<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetDonationsRelatoryQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<List<DonationViewModel>> Handle(GetDonationsRelatoryQuery request, CancellationToken cancellationToken)
        {

            var donationLast30Days = await _donationRepository.GetLast30Days();

            var donationRelatoryViewModel = donationLast30Days.ConvertDonationsViewModel();

            return donationRelatoryViewModel.ToList();

        }

    }
}
