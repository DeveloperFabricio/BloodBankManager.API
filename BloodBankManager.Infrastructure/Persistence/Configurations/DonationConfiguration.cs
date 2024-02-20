using BloodBankManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBankManager.Infrastructure.Persistence.Configurations
{
    internal class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasOne(d => d.Donor)
                .WithMany(d => d.Donations)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
