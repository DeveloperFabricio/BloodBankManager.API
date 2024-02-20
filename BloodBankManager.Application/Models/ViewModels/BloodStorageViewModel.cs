using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class BloodStorageViewModel
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
