using BloodBankManager.Core.Entities;
namespace BloodBankManager.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAllDonations();
        Task<List<Donation>> GetLast30Days();
        Task<Donation> GetDonationById(int id);
        Task CreateDonation(Donation donation);
        Task SaveChangesAsync();
    }
}
