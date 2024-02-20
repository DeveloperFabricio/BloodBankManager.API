using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsHandlers
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, List<AllDonorsViewModel>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<List<AllDonorsViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetAllDonorsAsync();

            var donorsViewModel = donors.ConvertDonorViewModel();

            return donorsViewModel.ToList();
        }
    }
}
