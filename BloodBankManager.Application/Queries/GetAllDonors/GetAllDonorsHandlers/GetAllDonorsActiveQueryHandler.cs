using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsHandlers
{
    public class GetAllDonorsActiveQueryHandler : IRequestHandler<GetAllDonorsActiveQuery, List<AllDonorsViewModel>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsActiveQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task <List<AllDonorsViewModel>> Handle(GetAllDonorsActiveQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetDonorsActive();

            var donorsViewModel = donors.ConvertDonorViewModel();

            return donorsViewModel.ToList();
        }
    }
}
