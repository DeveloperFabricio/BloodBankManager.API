using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManager.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankManagerDbContext _bloodBankManagerDbContext;
        public DonationRepository(BloodBankManagerDbContext bloodBankManagerDb)
        {
            _bloodBankManagerDbContext = bloodBankManagerDb;
        }

        public async Task CreateDonation(Donation donation)
        {
            await _bloodBankManagerDbContext.Donations.AddAsync(donation);

            await _bloodBankManagerDbContext.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetAllDonations()
        {
            return await _bloodBankManagerDbContext.Donations.Include(d => d.Donor).ToListAsync();
        }

        public async Task<Donation> GetDonationById(int id)
        {
            return await _bloodBankManagerDbContext.Donations.Include(d => d.Donor).SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Donation>> GetLast30Days()
        {
            return await _bloodBankManagerDbContext.Donations.Include(d => d.Donor).Where(d => d.DonationDate >= DateTime.Now.AddDays(-30)).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _bloodBankManagerDbContext.SaveChangesAsync();
        }
    }
}
