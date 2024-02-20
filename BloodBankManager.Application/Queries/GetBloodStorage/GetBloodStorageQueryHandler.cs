using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using BloodBankManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetBloodStorage
{
    public class GetBloodStorageQueryHandler : IRequestHandler<GetBloodStorageQuery, List<BloodStorageViewModel>>
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        public GetBloodStorageQueryHandler(IBloodStorageRepository bloodStorageRepository)
        {
            _bloodStorageRepository = bloodStorageRepository;
        }
        public async Task<List<BloodStorageViewModel>> Handle(GetBloodStorageQuery request, CancellationToken cancellationToken)
        {
            var storage = await _bloodStorageRepository.GetAllStorages();

            var storageViewModel = storage.ConvertBloodStoragesViewModel();

            return storageViewModel.ToList();
        }
    }
}
