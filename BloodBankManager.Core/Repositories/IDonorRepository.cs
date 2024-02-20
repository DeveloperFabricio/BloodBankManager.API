using BloodBankManager.Core.Entities;

namespace BloodBankManager.Core.Repositories
{
    public interface IDonorRepository
    {
        Task <List<Donor>> GetAllDonorsAsync();
        Task<Donor> GetDonorByIdAsync(int id);
        Task<Donor> GetDonorWithDonationsById(int id);
        Task<List<Donor>> GetDonorsActive();
        Task<List<Donor>> GetDonorsInactive();
        Task AddDonorAsync(Donor donor);
        Task SaveChangesAsync();
        Task DeleteDonorAsync(int id);
        Task ActivateDonor(int id);
        Task<bool> CheckEmailNoExists(string email);
    }
}
