using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.MappingViewModels
{
    public static class MappingDonorAndDonationsViewModel
    {
        public static DonorAndDonationsViewModel ConvertDonorAndDonationsViewModelById (this Donor donor)
        {
            return new DonorAndDonationsViewModel
            {
                FullName = donor.FullName,
                BloodType = donor.BloodType,
                RhFactor = donor.RhFactor,
                Active = donor.Active,
                Donations = MapDonations(donor.Donations)
            };
        }

        public static List<DonationViewModelRelatory> MapDonations(List<Donation> donations)
        {
            return donations.Select(donation => new DonationViewModelRelatory
            {
                DonationDate = donation.DonationDate.ToString("dd/MM/yyyy"),
                QuantityMl = donation.QuantityMl,
                BloodType = donation.Donor.BloodType,
                RhFactor = donation.Donor.RhFactor,

            }).ToList();
        }
    }
}
