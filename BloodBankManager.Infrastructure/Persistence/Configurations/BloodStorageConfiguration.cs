using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBankManager.Infrastructure.Persistence.Configurations
{
    internal class BloodStorageConfiguration : IEntityTypeConfiguration<BloodStorage>
    {
        public void Configure(EntityTypeBuilder<BloodStorage> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(p => p.BloodType)
                .HasConversion(b => b.ToString(), b => (BloodType)Enum.Parse(typeof(BloodType), b));

            builder
                .Property(r => r.RhFactor)
                .HasConversion(r => r.ToString(), r => (RhFactor)Enum.Parse(typeof(RhFactor), r));
        }
    }
}
