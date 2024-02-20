using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsHandlers
{
    public class GetAllDonorsInactiveQueryHandler : IRequestHandler<GetAllDonorsInactiveQuery, List<AllDonorsViewModel>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsInactiveQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository; 
        }
        public async Task<List<AllDonorsViewModel>> Handle(GetAllDonorsInactiveQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetDonorsInactive();

            var donorsViewModel = donors.ConvertDonorViewModel();

            return donorsViewModel.ToList();
        }
    }
}
