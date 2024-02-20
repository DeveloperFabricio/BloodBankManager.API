using BloodBankManager.Core.Enums;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class DonationViewModelRelatory
    {
        public string DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public RhFactor RhFactor { get; set; }
        public BloodType BloodType { get; set; }
    }
}
