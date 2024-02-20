using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManager.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankManagerDbContext _bloodBankManagerDbContext; 
        public DonorRepository(BloodBankManagerDbContext bloodBankManagerDb)
        {
            _bloodBankManagerDbContext = bloodBankManagerDb;
        }

        public async Task ActivateDonor(int id)
        {
            await _bloodBankManagerDbContext.SaveChangesAsync();
        }

        public async Task AddDonorAsync(Donor donor)
        {
            await _bloodBankManagerDbContext.Donors.AddAsync(donor);

            await _bloodBankManagerDbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckEmailNoExists(string email)
        {
            return await _bloodBankManagerDbContext.Donors.AnyAsync(e => e.Email == email);
        }

        public async Task DeleteDonorAsync(int id)
        {
            await _bloodBankManagerDbContext.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAllDonorsAsync()
        {
            return await _bloodBankManagerDbContext.Donors.ToListAsync();
        }

        public async Task<Donor> GetDonorByIdAsync(int id)
        {
            return await _bloodBankManagerDbContext.Donors
                                                   .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Donor>> GetDonorsActive()
        {
            return await _bloodBankManagerDbContext.Donors
                                                   .Where(d => d.Active)
                                                   .ToListAsync();
        }

        public async Task<List<Donor>> GetDonorsInactive()
        {
            return await _bloodBankManagerDbContext.Donors
                                                   .Where(d => !d.Active)
                                                   .ToListAsync();
        }

        public async Task<Donor> GetDonorWithDonationsById(int id)
        {
            return await _bloodBankManagerDbContext.Donors
                                                   .Include(d => d.Donations)
                                                   .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _bloodBankManagerDbContext.SaveChangesAsync();
        }
    }
}
