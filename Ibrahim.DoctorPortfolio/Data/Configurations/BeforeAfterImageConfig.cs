using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ibrahim.DoctorPortfolio.Data.Configurations
{
    public class BeforeAfterImageConfig : IEntityTypeConfiguration<BeforeAfterImage>
    {
        public void Configure(EntityTypeBuilder<BeforeAfterImage> builder)
        {
            builder.HasIndex(b => b.ImageType);

            builder.HasOne(b => b.Procedure).WithMany(p=>p.BeforeAfterImages).HasForeignKey(b => b.ProcedureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
