using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class DonorAndDonationsViewModel 
    {
        public string FullName { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public bool Active { get; set; }
        public List<DonationViewModelRelatory> Donations { get; set; }
    }
}
