using BloodBankManager.Application.Models.MappingViewModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetDonationsByDonor
{
    public class GetAllDonationsByDonorIdQueryHandler : IRequestHandler<GetAllDonationsByDonorIdQuery, DonorAndDonationsViewModel>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonationsByDonorIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<DonorAndDonationsViewModel> Handle(GetAllDonationsByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donorWithDonations = await _donorRepository.GetDonorWithDonationsById(request.Id);

            var donorWithDonationsViewModel = donorWithDonations.ConvertDonorAndDonationsViewModelById();

            return donorWithDonationsViewModel;
        }
    }
}
