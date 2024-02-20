using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetAllDonationsQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<List<DonationViewModel>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetAllDonations();

            var donationsViewModels = donations.ConvertDonationsViewModel();

            return donationsViewModels.ToList();
        }
    }
}
