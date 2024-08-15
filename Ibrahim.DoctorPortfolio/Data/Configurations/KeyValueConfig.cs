using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ibrahim.DoctorPortfolio.Data.Configurations
{
    public class KeyValueConfig : IEntityTypeConfiguration<KeyValue>
    {
        public void Configure(EntityTypeBuilder<KeyValue> builder)
        {
            builder.HasIndex(k => k.Key).IsUnique();
        }
    }
}
