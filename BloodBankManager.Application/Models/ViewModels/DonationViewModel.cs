using BloodBankManager.Core.Enums;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class DonationViewModel
    {
        public string FullName { get; set; }
        public string DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public RhFactor RhFactor { get; set; }
        public BloodType BloodType { get; set; }
    }
}
