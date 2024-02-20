using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetStorageById
{
    public class GetStorageByIdQueryHandler : IRequestHandler<GetStorageByIdQuery, BloodStorageViewModel>
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        public GetStorageByIdQueryHandler(IBloodStorageRepository bloodStorageRepository)
        {
            _bloodStorageRepository = bloodStorageRepository;
        }
        public async Task<BloodStorageViewModel> Handle(GetStorageByIdQuery request, CancellationToken cancellationToken)
        {
            var storage = await _bloodStorageRepository.GetStorageById(request.Id);

            var storageViewModel = storage.ConvertBloodStorageViewModelById();

            return storageViewModel;
        }
    }
}
