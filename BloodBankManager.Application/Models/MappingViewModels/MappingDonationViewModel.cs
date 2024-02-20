using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Core.Entities;


namespace BloodBankManager.Application.ViewModels.MappingViewModels
{
    public static class MappingDonationViewModel
    {
        public static IEnumerable<DonationViewModel> ConvertDonationsViewModel(
            this IEnumerable<Donation> donations)
        {
            return (from donation in donations
                    select new DonationViewModel
                    {
                        FullName = donation.Donor.FullName,
                        DonationDate = donation.DonationDate.ToString("dd/MM/yyyy"),
                        QuantityMl = donation.QuantityMl,
                        BloodType = donation.Donor.BloodType,
                        RhFactor = donation.Donor.RhFactor,

                    }).ToList();
        }

        public static DonationViewModel ConvertDonationViewModelById(this Donation donation)
        {
            return new DonationViewModel
            {
                FullName = donation.Donor.FullName,
                DonationDate = donation.DonationDate.ToString("dd/MM/yyyy"),
                QuantityMl = donation.QuantityMl,
                BloodType = donation.Donor.BloodType,
                RhFactor = donation.Donor.RhFactor,
            };
        }
    }
}
