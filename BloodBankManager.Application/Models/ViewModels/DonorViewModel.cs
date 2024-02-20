using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class DonorViewModel
    {
        public string ?FullName { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public Address ?Address { get; set; }
        public bool Active { get; set; }
    }
}
