
using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;

namespace BloodBankManager.Core.Repositories
{
    public interface IBloodStorageRepository
    {
        Task<List<BloodStorage>> GetAllStorages();
        Task<BloodStorage> GetStorageById(int id);
        Task<BloodStorage> GetBloodTypeAndRhFactor(BloodType bloodType, RhFactor rhFactor);
        void UpdateStorage(BloodStorage bloodStorage);
    }
}
