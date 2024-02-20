using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Core.Entities;

namespace BloodBankManager.Application.ViewModels.MappingViewModels
{
    public static class MappingBloodStorageViewModel
    {
        public static IEnumerable<BloodStorageViewModel> ConvertBloodStoragesViewModel(this IEnumerable<BloodStorage> bloodStorages)
        {
            return (from bloodStorage in bloodStorages
                    select new BloodStorageViewModel
                    {
                        BloodType = bloodStorage.BloodType,
                        RhFactor = bloodStorage.RhFactor,
                        QuantityMl = bloodStorage.QuantityMl

                    }).ToList();
        }

        public static BloodStorageViewModel ConvertBloodStorageViewModelById(this BloodStorage bloodStorage)
        {
            return new BloodStorageViewModel
            {
                BloodType = bloodStorage.BloodType,
                RhFactor = bloodStorage.RhFactor,
                QuantityMl = bloodStorage.QuantityMl
            };
        }
    }
}
