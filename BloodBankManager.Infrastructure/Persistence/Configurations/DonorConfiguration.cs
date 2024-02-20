using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodBankManager.Infrastructure.Persistence.Configurations
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder
                 .HasKey(d => d.Id);

            builder
                .HasMany(d => d.Donations)
                .WithOne(d => d.Donor)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(a => a.Address)
                .Property(s => s.Street)
                .HasColumnName("Street");
                

            builder
                .OwnsOne(a => a.Address)
                .Property(s => s.State)
                .HasColumnName("State");

            builder
                .OwnsOne(a => a.Address)
                .Property(c => c.City)
                .HasColumnName("City");

            builder
                .OwnsOne(a => a.Address)
                .Property(z => z.ZipCode)
                .HasColumnName("ZipCode");

            builder
                .Property(g => g.Gender)
                .HasConversion(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g));

            builder
                .Property(p => p.BloodType)
                .HasConversion(b => b.ToString(), b => (BloodType)Enum.Parse(typeof(BloodType), b));

            builder
                .Property(r => r.RhFactor)
                .HasConversion(r => r.ToString(), r => (RhFactor)Enum.Parse(typeof(RhFactor), r));
        }
    }
}
