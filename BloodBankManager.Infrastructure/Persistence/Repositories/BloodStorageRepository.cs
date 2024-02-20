using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using BloodBankManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.Persistence.Repositories
{
    public class BloodStorageRepository : IBloodStorageRepository
    {
        private readonly BloodBankManagerDbContext _bloodBankManagerDbContext;
        public BloodStorageRepository(BloodBankManagerDbContext bloodBankManagerDb)
        {
            _bloodBankManagerDbContext = bloodBankManagerDb;
        }

        public async Task<List<BloodStorage>> GetAllStorages()
        {
            return await _bloodBankManagerDbContext.BloodStorages.ToListAsync();
        }

        public async Task<BloodStorage> GetBloodTypeAndRhFactor(BloodType bloodType, RhFactor rhFactor)
        {
            return await _bloodBankManagerDbContext.BloodStorages
                .SingleOrDefaultAsync(b => b.BloodType == bloodType && b.RhFactor == rhFactor);
        }

        public async Task<BloodStorage> GetStorageById(int id)
        {
            return await _bloodBankManagerDbContext.BloodStorages.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void UpdateStorage(BloodStorage bloodStorage)
        {
            _bloodBankManagerDbContext.BloodStorages.Update(bloodStorage);

            _bloodBankManagerDbContext.SaveChangesAsync();
        }
    }
}
