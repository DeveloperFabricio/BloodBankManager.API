using BloodBankManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Services
{
    public interface IDonorService
    {
        Task<bool> CheckDonorIsValid(Donor donor);
    }
}
