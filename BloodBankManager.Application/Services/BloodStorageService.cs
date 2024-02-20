using BloodBankManager.Core.Repositories;
using BloodBankManager.Core.Services;

namespace BloodBankManager.Application.Services
{
    public class BloodStorageService : IBloodStorageService
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        private readonly IDonorRepository _donorRepository;

        public BloodStorageService(IBloodStorageRepository bloodStorageRepository, IDonorRepository donorRepository)
        {
            _bloodStorageRepository = bloodStorageRepository;
            _donorRepository = donorRepository;
        }

        public async Task AddBloodStorage(int donorId, int quantityMl)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(donorId);

            var storage = await _bloodStorageRepository
                                .GetBloodTypeAndRhFactor(donor.BloodType, donor.RhFactor);

           storage.UpdateQuantity(quantityMl);

            _bloodStorageRepository.UpdateStorage(storage);


        }
    }
}
