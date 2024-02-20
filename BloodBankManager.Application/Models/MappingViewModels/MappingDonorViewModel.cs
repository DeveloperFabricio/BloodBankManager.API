using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Core.Entities;

namespace BloodBankManager.Application.ViewModels.MappingViewModels
{
    public static class MappingDonorViewModel
    {
        public static IEnumerable<AllDonorsViewModel> ConvertDonorViewModel(this IEnumerable<Donor> donors)
        {
            return (from donor in donors
                    select new AllDonorsViewModel
                    {
                        FullName = donor.FullName,
                        Gender = donor.Gender,
                        Weight = donor.Weight,
                        BloodType = donor.BloodType,
                        RhFactor = donor.RhFactor,
                        Active = donor.Active,

                    }).ToList();
        }

        public static DonorViewModel ConvertDonorViewModelById(this Donor donor)
        {
            return new DonorViewModel
            {
                FullName = donor.FullName,
                Gender = donor.Gender,
                Weight = donor.Weight,
                BloodType = donor.BloodType,
                RhFactor = donor.RhFactor,
                Address = donor.Address,
                Active = donor.Active
            };
        }

    }
}
