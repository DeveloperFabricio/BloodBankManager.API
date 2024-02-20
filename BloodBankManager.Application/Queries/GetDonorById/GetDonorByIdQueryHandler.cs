using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Queries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, DonorViewModel>
    {
        private readonly IDonorRepository _donorRepository;
        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<DonorViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(request.Id);

            var donorViewModel = donor.ConvertDonorViewModelById();

            return donorViewModel;
        }
    }
}
