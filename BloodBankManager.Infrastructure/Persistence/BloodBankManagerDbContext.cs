using BloodBankManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBankManager.Infrastructure.Persistence
{
    public class BloodBankManagerDbContext : DbContext
    {
        public BloodBankManagerDbContext(DbContextOptions<BloodBankManagerDbContext> options) : base(options) { }
        
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStorage> BloodStorages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
